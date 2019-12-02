using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessObjects.Interfaces
{
    public interface IRepository
    {
		IList<Album>GetAlbums();
		IList<Album> GetAlbumsForUser(int userId);

	}
}
