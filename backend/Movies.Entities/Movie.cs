using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Entities
{
    public class Movie
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int MovieId { get; set; }
		[Required]
		[StringLength(200)]
		public string Name { get; set; }
		[Required]
		[StringLength(500)]
		public string Description { get; set; }
		[Required]
		public decimal Rating { get; set; }
		[Required]
		public string Length { get; set; }
		//[Required]
		public string Image { get; set; }
		public ICollection<Genre> Genres { get; set; }
	}
}
