using BusinessObjects;
using BusinessObjects.Interfaces;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
			Repository = new APIRepository();

		}

		[TestMethod]
        public void GetAlbumsReturnsData()
        {
			var result = Repository.GetAlbums().ToList();

			Assert.IsInstanceOfType(result, typeof(List<Album>), "Wrong datatype returned");
			Assert.IsNotNull(result, "Albums not returned");
			Assert.AreNotEqual(0, result, "Invalid album count returned");
        }
    }
}
