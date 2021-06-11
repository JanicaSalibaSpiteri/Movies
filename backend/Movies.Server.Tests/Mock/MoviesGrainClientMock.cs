using Movies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Server.Tests.Mock
{
    public class MoviesGrainClientMock : IMoviesGrainClient
    {
        private readonly List<MovieModel> _movies;

        public MoviesGrainClientMock()
        {
            _movies = new List<MovieModel>();
        }

        public Task<List<MovieModel>> FilterByGenre(string genre) => Task.FromResult(_movies.Where(x => x.Genres.Contains(genre, StringComparer.OrdinalIgnoreCase)).ToList());

        public Task<List<MovieModel>> GetAllMovies() => Task.FromResult(_movies);

        public Task<MovieModel> GetMovieById(string id) => Task.FromResult(_movies.SingleOrDefault(x => x.Id == id));

        public Task<List<MovieModel>> GetTop5Movies() => Task.FromResult(_movies.OrderByDescending(x => x.Rating).Take(5).ToList());

        public Task<List<MovieModel>> SearchByName(string name) => Task.FromResult(_movies.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList());

        public Task CreateMovie(string name, string description, string length, decimal rating, string image, List<string> genres)
        {
            _movies.Add(new MovieModel
            {
                Id = (_movies.Count() + 1).ToString(),
                Name = name,
                Description = description,
                Length = length,
                Rating = rating,
                Image = image,
                Genres = genres
            });

            return Task.CompletedTask;
        }

        public Task UpdateMovie(string id, string name, string description, string length, decimal rating, string image, List<string> genres)
        {
            var myMovieIndex = _movies.IndexOf(_movies.Find(x => x.Id == id));
            if (myMovieIndex == -1)
            {
                throw new Exception("Requested movie does not exist");
            }

            var myMovie = _movies.SingleOrDefault(x => x.Id == id);

            if (myMovie != null)
            {
                myMovie.Name = name;
                myMovie.Description = description;
                myMovie.Length = length;
                myMovie.Rating = rating;
                myMovie.Image = image;
                myMovie.Genres = genres;
            }
            _movies[myMovieIndex] = myMovie;

            return Task.CompletedTask;
        }
    }
}
