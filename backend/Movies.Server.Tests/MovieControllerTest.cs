using Microsoft.Extensions.Caching.Memory;
using Movies.Contracts;
using Movies.Server.Controllers;
using Movies.Server.Tests.Mock;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Movies.Server.Tests
{
    public class MovieControllerTest
    {
        private readonly MovieController _controller;
        private readonly IMoviesGrainClient _client;

        public MovieControllerTest()
        {
            _client = new MoviesGrainClientMock();
            _controller = new MovieController(_client, new MemoryCache(new MemoryCacheOptions()));
        }

        [Fact]
        public void AddMovie_Success()
        {
            MovieModel movie = new MovieModel
            {
                Name = "Finding Nemo",
                Description = "Finding Nemo movie",
                Rating = 9.5M,
                Length = "1hr 35mins",
                Image = "finding-nemo.jpg",
                Genres = new List<string>
                {
                    "Adventure", "Comedy"
                }
            };

            _ = _controller.CreateMovie(movie);

            List<MovieModel> allMovies = _controller.GetAllMovies().Result;
            Assert.Contains(allMovies, item => item.Name == movie.Name);
        }

        [Fact]
        public void UpdateMovie_Success()
        {
            MovieModel movie = new MovieModel
            {
                Name = "Finding Nemo",
                Description = "Finding Nemo movie",
                Rating = 9.5M,
                Length = "1hr 35mins",
                Image = "finding-nemo.jpg",
                Genres = new List<string>
                {
                    "Adventure", "Comedy"
                }
            };

            _ = _controller.CreateMovie(movie);

            List<MovieModel> allMovies = _controller.GetAllMovies().Result;

            var createdMovie = allMovies.SingleOrDefault(x => x.Name == movie.Name);

            //Update movie rating & add new genre
            movie.Rating = 10.0M;
            movie.Genres.Add("Animated");

            _ = _controller.UpdateMovie(createdMovie.Id, movie);

            allMovies = _controller.GetAllMovies().Result;

            //Check that there is still 1 movie in the list
            Assert.Single(allMovies);

            var updatedMovie = allMovies.SingleOrDefault(x => x.Name == movie.Name);

            Assert.Equal(movie.Rating, updatedMovie.Rating);
            Assert.Equal(3, updatedMovie.Genres.Count());
            Assert.Contains("Animated", updatedMovie.Genres);
        }

        [Fact]
        public void GetAllMovies_Success()
        {
            MovieModel movie1 = new MovieModel
            {
                Name = "Finding Nemo",
                Description = "Finding Nemo movie",
                Rating = 9.5M,
                Length = "1hr 35mins",
                Image = "finding-nemo.jpg",
                Genres = new List<string>
                {
                    "Adventure", "Comedy"
                }
            };

            MovieModel movie2 = new MovieModel
            {
                Name = "Annabelle",
                Description = "Annabelle movie",
                Rating = 8.3M,
                Length = "2hr 5mins",
                Image = "annabelle.jpg",
                Genres = new List<string>
                {
                    "Horror", "Thriller", "Mystery"
                }
            };

            _ = _controller.CreateMovie(movie1);

            List<MovieModel> allMovies = _controller.GetAllMovies().Result;
            Assert.Single(allMovies);
            Assert.Contains(allMovies, item => item.Name == movie1.Name);

            _ = _controller.CreateMovie(movie2);

            allMovies = _controller.GetAllMovies().Result;
            Assert.Equal(2, allMovies.Count());
            Assert.Contains(allMovies, item => item.Name == movie2.Name);
        }

        [Fact]
        public void GetMovieById_Success()
        {
            MovieModel movie1 = new MovieModel
            {
                Name = "Finding Nemo",
                Description = "Finding Nemo movie",
                Rating = 9.5M,
                Length = "1hr 35mins",
                Image = "finding-nemo.jpg",
                Genres = new List<string>
                {
                    "Adventure", "Comedy"
                }
            };

            MovieModel movie2 = new MovieModel
            {
                Name = "Annabelle",
                Description = "Annabelle movie",
                Rating = 8.3M,
                Length = "2hr 5mins",
                Image = "annabelle.jpg",
                Genres = new List<string>
                {
                    "Horror", "Thriller", "Mystery"
                }
            };

            _ = _controller.CreateMovie(movie1);
            _ = _controller.CreateMovie(movie2);

            var allMovies = _controller.GetAllMovies().Result;
            Assert.Equal(2, allMovies.Count());

            var myMovie2 = allMovies.SingleOrDefault(x => x.Name == movie2.Name);

            var getMovie = _controller.GetMovieById(myMovie2.Id).Result;
            Assert.NotNull(getMovie);
            Assert.Equal(movie2.Name, getMovie.Name);
        }

        [Fact]
        public void GetTop5Movies_Success()
        {
            List<MovieModel> myMovies = new List<MovieModel>
            {
                new MovieModel
                {
                    Name = "Finding Nemo",
                    Description = "Finding Nemo movie",
                    Rating = 9.5M,
                    Length = "1hr 35mins",
                    Image = "finding-nemo.jpg",
                    Genres = new List<string>
                    {
                        "Adventure", "Comedy"
                    }
                },
                new MovieModel
                {
                    Name = "Annabelle",
                    Description = "Annabelle movie",
                    Rating = 7.5M,
                    Length = "2hr 5mins",
                    Image = "annabelle.jpg",
                    Genres = new List<string>
                    {
                        "Horror", "Thriller", "Mystery"
                    }
                },
                new MovieModel
                {
                    Name = "Minions",
                    Description = "Minions movie",
                    Rating = 8.7M,
                    Length = "1hr 19mins",
                    Image = "minions.jpg",
                    Genres = new List<string>
                    {
                        "Adventure", "Animated"
                    }
                },
                new MovieModel
                {
                    Name = "Deadpool",
                    Description = "Deadpool movie",
                    Rating = 8.6M,
                    Length = "2hr 5mins",
                    Image = "deadpool.jpg",
                    Genres = new List<string>
                    {
                        "Action", "Adventure", "Comedy"
                    }
                },
                new MovieModel
                {
                    Name = "Gangster Squad",
                    Description = "Gangster Squad movie",
                    Rating = 6.8M,
                    Length = "1hr 35mins",
                    Image = "gangster-squad.jpg",
                    Genres = new List<string>
                    {
                        "Action", "Crime", "Drama"
                    }
                },
                new MovieModel
                {
                    Name = "The Hangover",
                    Description = "The Hangover movie",
                    Rating = 7.0M,
                    Length = "2hr 5mins",
                    Image = "the-hangover.jpg",
                    Genres = new List<string>
                    {
                        "Horror", "Thriller", "Mystery"
                    }
                }
                //movie1,movie2,movie3,movie4,movie5,movie6
            };

            foreach (var movie in myMovies)
            {
                _ = _controller.CreateMovie(movie);
            }

            var allMovies = _controller.GetAllMovies().Result;
            var expectedMovies = allMovies.OrderByDescending(x => x.Rating).Take(5).ToList();

            var top5Movies = _controller.GetTop5Movies().Result;
            Assert.Equal(5, top5Movies.Count());

            Assert.Equal(expectedMovies, top5Movies);
        }

        [Fact]
        public void SearchByName_Success()
        {
            MovieModel movie1 = new MovieModel
            {
                Name = "Finding Nemo",
                Description = "Finding Nemo movie",
                Rating = 9.5M,
                Length = "1hr 35mins",
                Image = "finding-nemo.jpg",
                Genres = new List<string>
                {
                    "Adventure", "Comedy"
                }
            };

            MovieModel movie2 = new MovieModel
            {
                Name = "Annabelle",
                Description = "Annabelle movie",
                Rating = 8.3M,
                Length = "2hr 5mins",
                Image = "annabelle.jpg",
                Genres = new List<string>
                {
                    "Horror", "Thriller", "Mystery"
                }
            };

            _ = _controller.CreateMovie(movie1);
            _ = _controller.CreateMovie(movie2);

            var allMovies = _controller.GetAllMovies().Result;
            Assert.Equal(2, allMovies.Count());

            var searchMovies = _controller.SearchByName(movie2.Name.ToUpper()).Result;
            Assert.Single(searchMovies);
            Assert.Contains(searchMovies, item => item.Name == movie2.Name);
        }

        [Fact]
        public void FilterByGenre_Success()
        {
            MovieModel movie1 = new MovieModel
            {
                Name = "Finding Nemo",
                Description = "Finding Nemo movie",
                Rating = 9.5M,
                Length = "1hr 35mins",
                Image = "finding-nemo.jpg",
                Genres = new List<string>
                {
                    "Adventure", "Comedy"
                }
            };

            MovieModel movie2 = new MovieModel
            {
                Name = "Annabelle",
                Description = "Annabelle movie",
                Rating = 8.3M,
                Length = "2hr 5mins",
                Image = "annabelle.jpg",
                Genres = new List<string>
                {
                    "Horror", "Thriller", "Mystery"
                }
            };

            _ = _controller.CreateMovie(movie1);
            _ = _controller.CreateMovie(movie2);

            var allMovies = _controller.GetAllMovies().Result;
            Assert.Equal(2, allMovies.Count());

            var searchMovies = _controller.FilterByGenre("thriller").Result;
            Assert.Single(searchMovies);
            Assert.Contains(searchMovies, item => item.Name == movie2.Name);
        }
    }
}
