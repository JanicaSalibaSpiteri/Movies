using System;
using System.Collections.Generic;

namespace Movies.Contracts
{
	[Serializable]
	public class MovieState
	{
		public List<MovieModel> Movies { get; set; }

		public MovieState()
		{
			Movies = new List<MovieModel>();
		}
	}
}
