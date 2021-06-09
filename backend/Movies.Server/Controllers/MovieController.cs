using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : Controller
	{
		private readonly IMoviesGrainClient _client;

		public MovieController(IMoviesGrainClient client)
		{
			_client = client;
		}

		// GET api/movie/
		[HttpGet]
		public async Task<List<MovieModel>> GetAllMovies()
		{
			var result = await _client.GetAllMovies().ConfigureAwait(false);
			return result;
		}

		// POST api/movie
		[HttpPost]
		[Consumes(MediaTypeNames.Application.Json)]
		public async Task CreateMovie([FromBody] MovieModel movie)
			=> await _client.CreateMovie(movie.Name, movie.Description, movie.Length, movie.Rating, movie.Image, movie.Genres).ConfigureAwait(false);

		// POST api/movie/1
		[HttpPost("{id}")]
		[Consumes(MediaTypeNames.Application.Json)]
		public async Task UpdateMovie([FromRoute] string id, [FromBody] MovieModel movie) => await _client.UpdateMovie(id, movie.Name, movie.Description, movie.Length, movie.Rating, movie.Image, movie.Genres).ConfigureAwait(false);

		// GET api/movie/1
		[HttpGet("{id}")]
		public async Task<MovieModel> GetMovieById(string id)
		{
			var result = await _client.GetMovieById(id).ConfigureAwait(false);
			return result;
		}

		// GET api/movie/GetTop5
		[HttpGet]
		[Route("GetTop5")]
		public async Task<List<MovieModel>> GetTop5Movies()
		{
			var result = await _client.GetTop5Movies().ConfigureAwait(false);
			return result;
		}

		// GET api/movie/SearchByName/Deadpool
		[HttpGet("SearchByName/{name}")]
		[Route("SearchByName")]
		public async Task<List<MovieModel>> SearchByName(string name)
		{
			var result = await _client.SearchByName(name).ConfigureAwait(false);
			return result;
		}

		// GET api/movie/FilterByGenre/Horror
		[HttpGet("FilterByGenre/{genre}")]
		[Route("FilterByGenre")]
		public async Task<List<MovieModel>> FilterByGenre(string genre)
		{
			var result = await _client.FilterByGenre(genre).ConfigureAwait(false);
			return result;
		}
	}
}
