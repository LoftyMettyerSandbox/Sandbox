using BusinessObjects.Interfaces;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AlbumsController : ControllerBase
	{

		private IRepository Repository = new APIRepository();

		[HttpGet]
		public ActionResult<string> Get()
		{
			var data = Repository.GetAlbums();
			return JsonConvert.SerializeObject(data, Formatting.Indented);
		}

		[HttpGet("{userid}")]
		public ActionResult<string> GetForUser(int userId)
		{
			var data = Repository.GetAlbumsForUser(userId);
			return JsonConvert.SerializeObject(data, Formatting.Indented);
		}

	}
}
