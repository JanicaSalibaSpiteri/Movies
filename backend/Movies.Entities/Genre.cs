using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Entities
{
	public class Genre
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GenreId { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		public ICollection<Movie> Movies { get; set; }
	}
}
