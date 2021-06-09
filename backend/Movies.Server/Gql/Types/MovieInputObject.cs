using GraphQL.Types;
using Movies.Contracts;

namespace Movies.Server.Gql.Types
{
	public class MovieInputObject : InputObjectGraphType<MovieModel>
	{
		public MovieInputObject()
		{
			Name = "MovieInput";
			Description = "A movie object";

			Field(x => x.Id, nullable: true).Description("Unique key");
			Field(x => x.Name).Description("Name of the movie");
			Field(x => x.Description).Description("Description of the movie");
			Field(x => x.Length).Description("Running time of the movie");
			Field(x => x.Rating).Description("Rating out of 10");
			Field(x => x.Image).Description("Movie image");
			Field(x => x.Genres).Description("List of genres");
		}
	}
}
