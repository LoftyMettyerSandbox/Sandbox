using BusinessObjects;
using BusinessObjects.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

		private IRepository Repository { get; set; }

		[TestInitialize]
		public void Initialise()
		{

			//Repository = new MockRepository();
			Repository = new Repository();

		}

		[TestMethod]
        public void GetAllAlbumReturnsData()
        {
			var result = Repository.GetAlbums(0);

			Assert.IsInstanceOfType(result, typeof(List<Album>), "Wrong datatype returned");
			Assert.IsNotNull(result, "Albums not returned");
			Assert.AreNotEqual(0, result.Count, "Invalid album count returned");
        }
    }
}
