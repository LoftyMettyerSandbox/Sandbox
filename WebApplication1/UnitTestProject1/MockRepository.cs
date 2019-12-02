using System.Collections.Generic;
using System.IO;
using BusinessObjects;
using BusinessObjects.Interfaces;

namespace UnitTestProject1
{
	class MockRepository : IRepository
	{
		public IList<Album> GetAlbums(int id)
		{
			var myJsonString = File.ReadAllText("MockData\\albums.json");
			return new List<Album>();
		}
	}
}
