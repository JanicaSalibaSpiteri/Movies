using GraphQL;
using GraphQL.Types;
using Movies.Contracts;
using Movies.Server.Gql.Types;

namespace Movies.Server.Gql.App
{
	public class MoviesGraphMutation : ObjectGraphType
	{
		public MoviesGraphMutation(IMoviesGrainClient moviesClient)
		{
			Name = "MoviesMutations";

			//Add a new movie
			Field<MovieGraphType>("addMovie",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<MovieInputObject>>
					{
						Name = "movie"
					}),
				resolve: context =>
				{
					var movie = context.GetArgument<MovieModel>("movie");

					return moviesClient.CreateMovie(movie.Name,
						movie.Description,
						movie.Length,
						movie.Rating,
						movie.Image,
						movie.Genres);
				});

			//Update an existing movie
			Field<MovieGraphType>("updateMovie",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<MovieInputObject>>
					{
						Name = "movie"
					}),
				resolve: context =>
				{
					var movie = context.GetArgument<MovieModel>("movie");

					return moviesClient.UpdateMovie(movie.Id, movie.Name,
						movie.Description, movie.Length, movie.Rating,
						movie.Image, movie.Genres);
				});
		}
	}
}