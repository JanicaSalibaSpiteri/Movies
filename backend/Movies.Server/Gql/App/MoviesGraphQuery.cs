using GraphQL;
using GraphQL.Types;
using Movies.Contracts;
using Movies.Server.Gql.Types;
using System.Collections.Generic;

namespace Movies.Server.Gql.App
{
	public class MoviesGraphQuery : ObjectGraphType
	{
		public MoviesGraphQuery(IMoviesGrainClient moviesClient)
		{
			Name = "MoviesQueries";

			//Search by movie name OR filter by genre OR get top 5 movies OR get all movies
			Field<ListGraphType<MovieGraphType>>("movies",
				arguments: new QueryArguments(new List<QueryArgument>
				{
					new QueryArgument<StringGraphType>
					{
						Name = "genre"
					},
					new QueryArgument<StringGraphType>
					{
						Name = "name"
					},
					new QueryArgument<BooleanGraphType>
					{
						Name = "top5"
					}
				}),
				resolve: ctx =>
				{
					var genre = ctx.GetArgument<string>("genre");
					if (!string.IsNullOrEmpty(genre))
					{
						return moviesClient.FilterByGenre(genre);
					}

					var name = ctx.GetArgument<string>("name");
					if (!string.IsNullOrEmpty(name))
					{
						return moviesClient.SearchByName(name);
					}

					var top5 = ctx.GetArgument<bool?>("top5");
					if (top5.HasValue && (bool)top5)
					{
						return moviesClient.GetTop5Movies();
					}
					
					//If no argument was passed, get all movies
					return moviesClient.GetAllMovies();
				}
			);

			//Get a single movie by it's ID
			Field<MovieGraphType>("movie",
				arguments: new QueryArguments(new List<QueryArgument>
				{
					new QueryArgument<StringGraphType>
					{
						Name = "id"
					}
				}),
				resolve: ctx => moviesClient.GetMovieById(ctx.GetArgument<string>("id"))
			);
		}
	}
}
