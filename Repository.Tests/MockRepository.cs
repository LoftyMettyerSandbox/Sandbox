using Newtonsoft.Json;
using Repository.Interfaces;
using Repository.Objects;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.Tests
{
	class MockRepository : IRepository
	{
		public IEnumerable<Album> GetAlbums()
		{
			var albumString = File.ReadAllText("MockData\\albums.json");
			var photoString = File.ReadAllText("MockData\\photos.json");

			return JsonConvert.DeserializeObject<List<Album>>(albumString);
		}

		public IEnumerable<Album> GetAlbumsForUser(int userId) => GetAlbums().Where(a => a.UserId == userId).ToList();

	}
}
