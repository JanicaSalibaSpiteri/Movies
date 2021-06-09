using Movies.Contracts;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Grains
{
	[StorageProvider(ProviderName = "Default")]
	public class MoviesGrain : Grain<MovieState>, IMoviesGrain
	{
		public async Task<List<MovieModel>> GetAllMovies() => await Task.FromResult(State.Movies);

		public async Task<List<MovieModel>> GetTop5Movies() => await Task.FromResult(State.Movies.OrderByDescending(x => x.Rating).Take(5).ToList());

		public async Task<List<MovieModel>> SearchByName(string name) => (List<MovieModel>)await Task.FromResult(State.Movies.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList());

		public async Task<List<MovieModel>> FilterByGenre(string genre) => (List<MovieModel>)await Task.FromResult(State.Movies.Where(x => x.Genres.Contains(genre, StringComparer.OrdinalIgnoreCase)).ToList());

		public async Task<MovieModel> GetMovieById(string id) => (MovieModel)await Task.FromResult(State.Movies.SingleOrDefault(x => x.Id == id));

		public async Task CreateMovie(string name, string description, string length, decimal rating, string image, List<string> genres)
		{
			State.Movies.Add( 
				new MovieModel
				{
					Id = (State.Movies.Count() + 1).ToString(),
					Name = name,
					Description = description,
					Length = length,
					Rating = rating,
					Image = image,
					Genres = genres
				}
			);

			await WriteStateAsync();
		}

		public async Task UpdateMovie(string id, string name, string description, string length, decimal rating, string image, List<string> genres)
		{
			var myMovieIndex = State.Movies.IndexOf(State.Movies.Find(x => x.Id == id));
			if (myMovieIndex == -1)
			{
				throw new Exception("Requested movie does not exist");
			}

			var myMovie = State.Movies.SingleOrDefault(x => x.Id == id);

			if (myMovie != null)
			{
				myMovie.Name = name;
				myMovie.Description = description;
				myMovie.Length = length;
				myMovie.Rating = rating;
				myMovie.Image = image;
				myMovie.Genres = genres;
			}
			State.Movies[myMovieIndex] = myMovie;

			await WriteStateAsync();
		}
	}
}
