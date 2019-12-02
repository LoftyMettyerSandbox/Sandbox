using BusinessObjects;
using BusinessObjects.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DAL
{
	public class APIRepository : IRepository
	{

		private static readonly HttpClient client = new HttpClient();

		public IList<Album> GetAlbums(int id)
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
			var result = JsonConvert.DeserializeObject<List<Album>>(msg.Result);
	
			return result;

		}

	}
}