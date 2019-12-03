using BusinessObjects;
using BusinessObjects.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DAL
{
	public class APIRepository : IRepository
	{

		private static readonly HttpClient client = new HttpClient();


		public IEnumerable<Album> GetAlbums()
		{

			//webapi code cribbed from web - there are many different styles here, and with netcore 3 it all on teh move again!
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
			var stringTask = client.GetStringAsync("http://jsonplaceholder.typicode.com/albums");
			var msg = stringTask;
			// end code crib

			// The .Result is now making this synchronous. Depending on data and rest of app this may or may not bea good idea,
			// this is one area you may want to mark as a potential code smell.
			var albums = JsonConvert.DeserializeObject<List<Album>>(msg.Result);



			stringTask = client.GetStringAsync("http://jsonplaceholder.typicode.com/photos");
			msg = stringTask;
			var photos = JsonConvert.DeserializeObject<List<Photo>>(msg.Result);


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