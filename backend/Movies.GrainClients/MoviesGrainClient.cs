using Movies.Contracts;
using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.GrainClients
{
	public class MoviesGrainClient : IMoviesGrainClient
	{
		private readonly IGrainFactory _grainFactory;

		public MoviesGrainClient(IGrainFactory grainFactory)
		{
			_grainFactory = grainFactory;
		}

		public Task<List<MovieModel>> GetAllMovies()
		{
			var grain = _grainFactory.GetGrain<IMoviesGrain>(Guid.Empty);
			return grain.GetAllMovies();
		}

		public Task<List<MovieModel>> GetTop5Movies()
		{
			var grain = _grainFactory.GetGrain<IMoviesGrain>(Guid.Empty);
			return grain.GetTop5Movies();
		}

		public Task<MovieModel> GetMovieById(string id)
		{
			var grain = _grainFactory.GetGrain<IMoviesGrain>(Guid.Empty);
			return grain.GetMovieById(id);
		}

		public Task<List<MovieModel>> SearchByName(string name)
		{
			var grain = _grainFactory.GetGrain<IMoviesGrain>(Guid.Empty);
			return grain.SearchByName(name);
		}

		public Task<List<MovieModel>> FilterByGenre(string genre)
		{
			var grain = _grainFactory.GetGrain<IMoviesGrain>(Guid.Empty);
			return grain.FilterByGenre(genre);
		}

		public Task CreateMovie(string name, string description, string length, decimal rating, string image, List<string> genres)
		{
			var grain = _grainFactory.GetGrain<IMoviesGrain>(Guid.Empty);
			return grain.CreateMovie(name, description, length, rating, image, genres);
		}

		public Task UpdateMovie(string id, string name, string description, string length, decimal rating, string image, List<string> genres)
		{
			var grain = _grainFactory.GetGrain<IMoviesGrain>(Guid.Empty);
			return grain.UpdateMovie(id, name, description, length, rating, image, genres);
		}
	}
}
