using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Movies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : Controller
	{
		private readonly IMoviesGrainClient _client;
		private readonly IMemoryCache _memoryCache;

		private readonly string _cacheKey = "AllMovies";

		public MovieController(IMoviesGrainClient client, IMemoryCache memoryCache)
		{
			_client = client;
			_memoryCache = memoryCache;
		}

		// GET api/movie/
		[HttpGet]
		public async Task<List<MovieModel>> GetAllMovies()
		{
			if (!_memoryCache.TryGetValue(_cacheKey, out MovieState allMoviesCache))
			{
				allMoviesCache.Movies = await _client.GetAllMovies().ConfigureAwait(false);

				var cacheExpirationOptions = new MemoryCacheEntryOptions
				{
					AbsoluteExpiration = DateTime.Now.AddHours(6),
					Priority = CacheItemPriority.Normal,
					SlidingExpiration = TimeSpan.FromMinutes(5)
				};
				_memoryCache.Set(_cacheKey, allMoviesCache, cacheExpirationOptions);
			}
			return allMoviesCache.Movies;
		}

		// POST api/movie
		[HttpPost]
		[Consumes(MediaTypeNames.Application.Json)]
		public async Task CreateMovie([FromBody] MovieModel movie)
		{
			await _client.CreateMovie(movie.Name, movie.Description, movie.Length, movie.Rating, movie.Image, movie.Genres).ConfigureAwait(false);

			//Update cache
			_memoryCache.TryGetValue(_cacheKey, out MovieState allMoviesCache);
			var allMovies = await _client.GetAllMovies().ConfigureAwait(false);

			//If cache is empty, or cache is populated and values are different than the ones in storage,
			//then update the cache
			if (allMoviesCache.Movies == null ||
				(allMoviesCache.Movies != null && allMoviesCache.Movies.Count() > 0 && allMoviesCache.Movies != allMovies))
			{
				var cacheExpirationOptions = new MemoryCacheEntryOptions
				{
					AbsoluteExpiration = DateTime.Now.AddHours(6),
					Priority = CacheItemPriority.Normal,
					SlidingExpiration = TimeSpan.FromMinutes(5)
				};

				var allMoviesState = new MovieState
				{
					Movies = allMovies
				};
				_memoryCache.Set(_cacheKey, allMoviesState, cacheExpirationOptions);
			}
		}

		// POST api/movie/1
		[HttpPost("{id}")]
		[Consumes(MediaTypeNames.Application.Json)]
		public async Task UpdateMovie([FromRoute] string id, [FromBody] MovieModel movie)
		{
			await _client.UpdateMovie(id, movie.Name, movie.Description, movie.Length, movie.Rating, movie.Image, movie.Genres).ConfigureAwait(false);

			//Update cache
			_memoryCache.TryGetValue(_cacheKey, out MovieState allMoviesCache);
			var allMovies = await _client.GetAllMovies().ConfigureAwait(false);

			//If cache is empty, or cache is populated and values are different than the ones in storage,
			//then update the cache
			if (allMoviesCache.Movies == null ||
				(allMoviesCache.Movies != null && allMoviesCache.Movies.Count() > 0 && allMoviesCache.Movies != allMovies))
			{
				var cacheExpirationOptions = new MemoryCacheEntryOptions
				{
					AbsoluteExpiration = DateTime.Now.AddHours(6),
					Priority = CacheItemPriority.Normal,
					SlidingExpiration = TimeSpan.FromMinutes(5)
				};
				var allMoviesState = new MovieState
				{
					Movies = allMovies
				};
				_memoryCache.Set(_cacheKey, allMoviesState, cacheExpirationOptions);
			}
		}

		// GET api/movie/1
		[HttpGet("{id}")]
		public async Task<MovieModel> GetMovieById(string id)
		{
			MovieModel myMovie;
			if (_memoryCache.TryGetValue(_cacheKey, out MovieState allMovies))
			{
				myMovie = allMovies.Movies.SingleOrDefault(x => x.Id == id);
			}
			else
			{
				myMovie = await _client.GetMovieById(id).ConfigureAwait(false);
			}

			return myMovie;
		}

		// GET api/movie/GetTop5
		[HttpGet]
		[Route("GetTop5")]
		public async Task<List<MovieModel>> GetTop5Movies()
		{
			List<MovieModel> myMovies;
			if (_memoryCache.TryGetValue(_cacheKey, out MovieState allMovies))
			{
				myMovies = allMovies.Movies.OrderByDescending(x => x.Rating).Take(5).ToList();
			}
			else
			{
				myMovies = await _client.GetTop5Movies().ConfigureAwait(false);
			}

			return myMovies;
		}

		// GET api/movie/SearchByName/Deadpool
		[HttpGet("SearchByName/{name}")]
		[Route("SearchByName")]
		public async Task<List<MovieModel>> SearchByName(string name)
		{
			List<MovieModel> myMovies;
			if (_memoryCache.TryGetValue(_cacheKey, out MovieState allMovies))
			{
				myMovies = allMovies.Movies.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
			}
			else
			{
				myMovies = await _client.SearchByName(name).ConfigureAwait(false);
			}

			return myMovies;
		}

		// GET api/movie/FilterByGenre/Horror
		[HttpGet("FilterByGenre/{genre}")]
		[Route("FilterByGenre")]
		public async Task<List<MovieModel>> FilterByGenre(string genre)
		{
			List<MovieModel> myMovies;
			if (_memoryCache.TryGetValue(_cacheKey, out MovieState allMovies))
			{
				myMovies = allMovies.Movies.Where(x => x.Genres.Contains(genre, StringComparer.OrdinalIgnoreCase)).ToList();
			}
			else
			{
				myMovies = await _client.FilterByGenre(genre).ConfigureAwait(false);
			}

			return myMovies;
		}
	}
}
