using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMoviesGrainClient
	{
		Task<List<MovieModel>> GetAllMovies();
		Task<List<MovieModel>> GetTop5Movies();
		Task<MovieModel> GetMovieById(string id);
		Task<List<MovieModel>> SearchByName(string name);
		Task<List<MovieModel>> FilterByGenre(string genre);
		Task CreateMovie(string name, string description, string length, decimal rating, string image, List<string> genres);
		Task UpdateMovie(string id, string name, string description, string length, decimal rating, string image, List<string> genres);
	}
}
