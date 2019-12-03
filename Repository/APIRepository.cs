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

		private Task<string> GetDataFromAPI(string requestUri) {

			//webapi code cribbed from web - there are many different styles here, and with netcore 3 it all on teh move again!
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
			// this is one area you may want to mark as a potential code smell.
			var albums = JsonConvert.DeserializeObject<List<Album>>(
				GetDataFromAPI("http://jsonplaceholder.typicode.com/albums").Result);

			var photos = JsonConvert.DeserializeObject<List<Photo>>(
				GetDataFromAPI("http://jsonplaceholder.typicode.com/photos").Result);

			// I'm sure there's a cleverer way of doing this using linq!
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