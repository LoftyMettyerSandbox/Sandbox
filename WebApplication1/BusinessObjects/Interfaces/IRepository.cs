using System.Collections.Generic;

namespace BusinessObjects.Interfaces
{
    public interface IRepository
    {
		IEnumerable<Album> GetAlbums();
		IEnumerable<Album> GetAlbumsForUser(int userId);

	}
}
