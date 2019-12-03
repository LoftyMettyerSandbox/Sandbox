using Repository.Objects;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRepository
    {
		IEnumerable<Album> GetAlbums();
		IEnumerable<Album> GetAlbumsForUser(int userId);

	}
}
