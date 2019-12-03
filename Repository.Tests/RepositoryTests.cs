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
			Repository = new MockRepository();
		}

		[TestMethod]
        public void GetAlbumsReturnsData()
        {
			var result = Repository.GetAlbums().ToList();

			Assert.IsInstanceOfType(result, typeof(IEnumerable<Album>), "Wrong datatype returned");
			Assert.IsNotNull(result, "Albums not returned");
			Assert.AreEqual(100, result.Count(), "Invalid album count returned");
        }

		[TestMethod]
		public void AlbumsCanBeFilteredByUser() {

			var result = Repository.GetAlbumsForUser(3);
			Assert.AreEqual(10, result.Count(), "Invalid albums for user returned");
		}

	}
}
