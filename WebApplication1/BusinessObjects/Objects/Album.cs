using Newtonsoft.Json;
using System.Collections.Generic;

namespace BusinessObjects
{
	public class Album
	{
		[JsonProperty("userId")]
		public int UserId { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		public ICollection<Photo> Photos { get; set; }

	}
}
