using System.Collections.Generic;

namespace Movies.Contracts
{
	public class MovieModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<string> Genres { get; set; }
		public decimal Rating { get; set; }
		public string Length { get; set; }
		public string Image { get; set; }
	}
}
