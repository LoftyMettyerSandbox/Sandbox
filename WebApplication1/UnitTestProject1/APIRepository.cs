using BusinessObjects;
using BusinessObjects.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
	public class APIRepository : IRepository
	{
		public IEnumerable<Album> GetAlbums()
		{
			return new List<Album>();
		}

		public IEnumerable<Album> GetAlbumsForUser(int userId)
		{
			return GetAlbums().Where(a => a.UserId == userId);
		}
	}
}