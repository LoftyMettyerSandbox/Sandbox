using BusinessObjects.Interfaces;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

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
			var data = Repository.GetAlbums(0);
			return JsonConvert.SerializeObject(data, Formatting.Indented);
		}

		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			var data = Repository.GetAlbums(id);
			return JsonConvert.SerializeObject(data, Formatting.Indented);
		}

	}
}
