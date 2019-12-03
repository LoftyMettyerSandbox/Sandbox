using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Interfaces;
using Repository.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Tests
{
    [TestClass]
    public class RepositoryTests
    {

		private IRepository Repository { get; set; }

		[TestInitialize]
		public void Initialise()
		{

			//Repository = new MockRepository();
			Repository = new APIRepository();

		}

		[TestMethod]
        public void GetAlbumsReturnsData()
        {
			var result = Repository.GetAlbums().ToList();

			Assert.IsInstanceOfType(result, typeof(IEnumerable<Album>), "Wrong datatype returned");
			Assert.IsNotNull(result, "Albums not returned");
			Assert.AreNotEqual(0, result, "Invalid album count returned");
        }
    }
}
