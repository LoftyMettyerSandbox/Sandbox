using Newtonsoft.Json;
using Repository.Interfaces;
using Repository.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Repository
{
	public class APIRepository : IRepository
	{

		// Some refactoring notes.
		// It may be better to write this class with the repository as an injectable object as this would give more scope for mocking.
		// However at this stage I don't want to over engineer a working solution.

		private Task<string> GetDataFromAPI(string requestUri) {

			// webapi code cribbed from web - there are many different styles here, and with netcore 3 it all on the move again!
			// For the purposes of this project I've gone with using this off the shelf solultion.
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
			var stringTask = client.GetStringAsync(requestUri);
			var msg = stringTask;
			// end code crib

			return msg;

		}

		public IEnumerable<Album> GetAlbums()
		{

			// The .Result is now making this synchronous. Depending on data and rest of app this may or may not bea good idea,
			// this is one area you may want to mark as a potential code smell as synchronous code on the web can be problematic.
			var albums = JsonConvert.DeserializeObject<List<Album>>(
				GetDataFromAPI("http://jsonplaceholder.typicode.com/albums").Result);

			var photos = JsonConvert.DeserializeObject<List<Photo>>(
				GetDataFromAPI("http://jsonplaceholder.typicode.com/photos").Result);

			// Also these addresses would ideally be configured in an appsettings of some kind. Would consider refactoring for full solution,
			// as there maybe many more data sources and not all of the n web api.

			// I'm sure there's a better way of merging this data using linq. However for the purposes of this project and the timeframe this works.
			// This can be marked as an area to refactor.
			foreach (var album in albums) {
				album.Photos = photos.Where(p => p.AlbumId == album.Id).ToList();
			}
	
			return albums;

		}


		public IEnumerable<Album> GetAlbumsForUser(int userId)
		{
			// let linq do the hard work!
			return GetAlbums().Where(a => a.UserId == userId).ToList();
		}

	}
}