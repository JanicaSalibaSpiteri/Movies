using GraphQL.Types;
using Movies.Contracts;

namespace Movies.Server.Gql.Types
{
	public class MovieGraphType : ObjectGraphType<MovieModel>
	{
		public MovieGraphType()
		{
			Name = "Movie";
			Description = "A movie graphtype.";

			Field(x => x.Id, nullable: true).Description("Unique key.");
			Field(x => x.Name, nullable: true).Description("Name.");
			Field(x => x.Description, nullable: true).Description("Description");
			Field(x => x.Length, nullable: true).Description("Length");
			Field(x => x.Rating, nullable: true).Description("Rating");
			Field(x => x.Image, nullable: true).Description("Image");
			Field(x => x.Genres, nullable: true).Description("Genres");
		}
	}
}
