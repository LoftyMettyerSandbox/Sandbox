using System.Collections.Generic;
using System.IO;
using BusinessObjects;
using BusinessObjects.Interfaces;

namespace UnitTestProject1
{
	class MockRepository : IRepository
	{
		public IEnumerable<Album> GetAlbums()
		{
			var myJsonString = File.ReadAllText("MockData\\albums.json");
			return new List<Album>();
		}

		public IEnumerable<Album> GetAlbumsForUser(int userId)
		{
			throw new System.NotImplementedException();
		}
	}
}
