using BusinessObjects;
using BusinessObjects.Interfaces;
using System.Collections.Generic;

namespace DAL
{
	public class APIRepository : IRepository
	{
		public IList<Album> GetAlbums(int id)
		{


			return new List<Album>();
		}
	}
}