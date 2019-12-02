using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects.Interfaces
{
    public interface IRepository
    {
		IList<Album> GetAlbums(int id);
	}
}
