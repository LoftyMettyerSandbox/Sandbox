using Newtonsoft.Json;

namespace Repository.Objects
{
	public class Photo
	{

		// including jsonproperty attribute so that the class can use Proper Type casing whilst still presenting 
		// the json with camelcase. Rational for this is its naming convention standard for c# classes to be proper case
		// and its standard for json and angluar front end stuff to be camel case. I've had many an argument with UI
		// developers about this, and so this became a habit just to keep everyone happy!

		[JsonIgnore]
		public virtual Album Album { get; set; }

		[JsonProperty("albumid")]
		public int AlbumId { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("thumbnailUrl")]
		public string thumbnailUrl { get; set; }
	}
}
