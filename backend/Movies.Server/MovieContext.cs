using Microsoft.EntityFrameworkCore;
using Movies.Entities;
using System.Collections.Generic;

namespace Movies.Server
{
	public class MovieContext : DbContext
	{
		private readonly string _dbConnectionString = "Server=LPTMTB8-0110;Database=MoviesDB;Trusted_Connection=True;MultipleActiveResultSets=true;";

		public MovieContext() { }

		public MovieContext(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_dbConnectionString);

		public DbSet<Movie> Movies { get; set; }

		public DbSet<Genre> Genres { get; set; }

		private IEnumerable<Movie> DefaultMovies() => new List<Movie>
		{
			new Movie
			{
				MovieId = 1,
				Name = "Deadpool",
				Description = "A former Special Forces operative turned mercenary is subjected to a rogue experiment that leaves him with accelrated healing powers, adopting the alter ego Deadpool.",
				Length = "1hr 48mins",
				Rating = 8.6M,
				Image = ""
			},
			new Movie
			{
				MovieId = 2,
				Name = "We're the Millers",
				Description = "A veteran pot dealer creates a fake family as part of his plan to move a huge shipment of weed into the U.S. from Mexico.",
				Length = "1hr 50mins",
				Rating = 7.0M,
				Image = ""
			},
			new Movie
			{
				MovieId = 3,
				Name = "Straight Outta Compton",
				Description = "The group NWA emerges from the mean streets of Compton in Los Angeles, California, in the mid-1980s and revolutionizes Hip Hop culture with their music and tales about life in the hood.",
				Length = "2hr 27mins",
				Rating = 8.0M,
				Image = ""
			},
			new Movie
			{
				MovieId = 4,
				Name = "Gridiron Gang",
				Description = "Teenagers at a juvenile detention center, under the leadership of their counselor, gain self-esteem by playing football together.",
				Length = "2hr 5mins",
				Rating = 6.9M,
				Image = ""
			},
			new Movie
			{
				MovieId = 5,
				Name = "American Gangster",
				Description = "In 1970s America, a detective works to bring down the drug empire of Frank Lucas, a heroin kingpin from Manhattan, who is smuggling the drug into the country from the Far East.",
				Length = "2hr 37mins",
				Rating = 7.8M,
				Image = ""
			},
			new Movie
			{
				MovieId = 6,
				Name = "Gangster Squad",
				Description = "It's 1949 Los Angeles, the city is run by gangsters and a malicious mobster, Mickey Cohen. Determined to end the corruption, John O'Mara assembles a team of cops, ready to take down the ruthless leader and restore peace to the city.",
				Length = "1hr 53mins",
				Rating = 6.8M,
				Image = ""
			},
			new Movie
			{
				MovieId = 7,
				Name = "Now You See Me",
				Description = "An FBI agent and an Interpol detective track a team of illusionists who pull off bank heists during their performances and reward their audiences with the money.",
				Length = "1hr 55mins",
				Rating = 7.3M,
				Image = ""
			},
			new Movie
			{
				MovieId = 8,
				Name = "Jurassic World",
				Description = "A new theme park is built on the original site of Jurassic Park. Everything is going well until the park's newest attraction--a genetically modified giant stealth killing machine--escapes containment and goes on a killing spree.",
				Length = "2hr 4mins",
				Rating = 7.1M,
				Image = ""
			},
			new Movie
			{
				MovieId = 9,
				Name = "Mission: Impossible: Rogue Nation",
				Description = "Ethan and team take on their most impossible mission yet, eradicating the Syndicate - an International rogue organization as highly skilled as they are, committed to destroying the IMF.",
				Length = "2hr 11mins",
				Rating = 7.5M,
				Image = ""
			},
			new Movie
			{
				MovieId = 10,
				Name = "Spectre",
				Description = "A cryptic message from Bond's past sends him on a trail to uncover a sinister organization. While M battles political forces to keep the secret service alive, Bond peels back the layers of deceit to reveal the terrible truth behind SPECTRE.",
				Length = "2hr 28mins",
				Rating = 6.9M,
				Image = ""
			},
			new Movie
			{
				MovieId = 11,
				Name = "Legend",
				Description = "The film tells the story of the identical twin gangsters Reggie and Ronnie Kray, two of the most notorious criminals in British history, and their organised crime empire in the East End of London during the 1960s.",
				Length = "2hr 28mins",
				Rating = 7.0M,
				Image = ""
			},
			new Movie
			{
				MovieId = 12,
				Name = "Southpaw",
				Description = "Boxer Billy Hope turns to trainer Tick Wills to help him get his life back on track after losing his wife in a tragic accident and his daughter to child protection services.",
				Length = "2hr 4mins",
				Rating = 7.5M,
				Image = ""
			},
			new Movie
			{
				MovieId = 13,
				Name = "Bridge of Spies",
				Description = "During the Cold War, an American lawyer is recruited to defend an arrested Soviet spy in court, and then help the CIA facilitate an exchange of the spy for the Soviet captured American U2 spy plane pilot, Francis Gary Powers.",
				Length = "2hr 22mins",
				Rating = 7.7M,
				Image = ""
			},
			new Movie
			{
				MovieId = 14,
				Name = "Ant-Man",
				Description = "Armed with a super-suit with the astonishing ability to shrink in scale but increase in strength, cat burglar Scott Lang must embrace his inner hero and help his mentor, Dr. Hank Pym, plan and pull off a heist that will save the world.",
				Length = "1hr 57mins",
				Rating = 7.4M,
				Image = ""
			},
			new Movie
			{
				MovieId = 15,
				Name = "Fast & Furious 7",
				Description = "Deckard Shaw seeks revenge against Dominic Toretto and his family for his comatose brother.",
				Length = "2hr 17mins",
				Rating = 7.3M,
				Image = ""
			},
			new Movie
			{
				MovieId = 16,
				Name = "Tracers",
				Description = "Wanted by the Chinese mafia, a New York City bike messenger escapes into the world of parkour after meeting a beautiful stranger.",
				Length = "1hr 34mins",
				Rating = 5.6M,
				Image = ""
			},
			new Movie
			{
				MovieId = 17,
				Name = "Running Scared",
				Description = "A low-ranking thug is entrusted by his crime boss to dispose of a gun that killed corrupt cops, but things get out of control when the gun ends up in wrong hands.",
				Length = "2hr 2mins",
				Rating = 7.4M,
				Image = ""
			},
			new Movie
			{
				MovieId = 18,
				Name = "The Hangover",
				Description = "Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing. They make their way around the city in order to find their friend before his wedding.",
				Length = "1hr 40mins",
				Rating = 7.8M,
				Image = ""
			},
			new Movie
			{
				MovieId = 19,
				Name = "Project X",
				Description = "3 high school seniors throw a birthday party to make a name for themselves. As the night progresses, things spiral out of control as word of the party spreads.",
				Length = "1hr 28mins",
				Rating = 6.7M,
				Image = ""
			},
			new Movie
			{
				MovieId = 20,
				Name = "The Dark Knight",
				Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, the caped crusader must come to terms with one of the greatest psychological tests of his ability to fight injustice.",
				Length = "2hr 32mins",
				Rating = 9.0M,
				Image = ""
			},
			new Movie
			{
				MovieId = 21,
				Name = "The Tournament",
				Description = "Every seven years in an unsuspecting town, The Tournament takes place. A battle royale between 30 of the world's deadliest assassins. The last man standing receiving the $10,000,000 cash prize and the title of Worlds No 1, which itself carries the legendary million dollar a bullet price tag.",
				Length = "1hr 35mins",
				Rating = 6.1M,
				Image = ""
			},
			new Movie
			{
				MovieId = 22,
				Name = "The Matrix",
				Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
				Length = "2hr 16mins",
				Rating = 8.7M,
				Image = ""
			},
			new Movie
			{
				MovieId = 23,
				Name = "Bad Boys",
				Description = "Two hip detectives protect a murder witness while investigating a case of stolen heroin.",
				Length = "1hr 59mins",
				Rating = 6.8M,
				Image = ""
			},
			new Movie
			{
				MovieId = 24,
				Name = "The Man from U.N.C.L.E.",
				Description = "In the early 1960s, CIA agent Napoleon Solo and KGB operative Illya Kuryakin participate in a joint mission against a mysterious criminal organization, which is working to proliferate nuclear weapons.",
				Length = "1hr 56mins",
				Rating = 7.3M,
				Image = ""
			}
		};

		private IEnumerable<Genre> DefaultGenres() => new List<Genre>
		{
			new Genre { GenreId = 1, Name = "Action" },
			new Genre { GenreId = 2, Name = "Adventure" },
			new Genre { GenreId = 3, Name = "Comedy" },
			new Genre { GenreId = 4, Name = "Crime" },
			new Genre { GenreId = 5, Name = "Biography" },
			new Genre { GenreId = 6, Name = "Drama" },
			new Genre { GenreId = 7, Name = "History" },
			new Genre { GenreId = 8, Name = "Sport" },
			new Genre { GenreId = 9, Name = "Mystery" },
			new Genre { GenreId = 10, Name = "Thriller" },
			new Genre { GenreId = 11, Name = "Scifi" }
		};

		private object[] DefaultMoviesGenres() => new object[]
		{
			//Movie 1
			new { MoviesMovieId = 1, GenresGenreId = 1 },
			new { MoviesMovieId = 1, GenresGenreId = 2 },
			new { MoviesMovieId = 1, GenresGenreId = 3 },
			//Movie 2
			new { MoviesMovieId = 2, GenresGenreId = 2 },
			new { MoviesMovieId = 2, GenresGenreId = 3 },
			new { MoviesMovieId = 2, GenresGenreId = 4 },
			//Movie 3
			new { MoviesMovieId = 3, GenresGenreId = 5 },
			new { MoviesMovieId = 3, GenresGenreId = 6 },
			new { MoviesMovieId = 3, GenresGenreId = 7 },
			//Movie 4
			new { MoviesMovieId = 4, GenresGenreId = 4 },
			new { MoviesMovieId = 4, GenresGenreId = 6 },
			new { MoviesMovieId = 4, GenresGenreId = 8 },
			//Movie 5
			new { MoviesMovieId = 5, GenresGenreId = 5 },
			new { MoviesMovieId = 5, GenresGenreId = 4 },
			new { MoviesMovieId = 5, GenresGenreId = 6 },
			//Movie 6
			new { MoviesMovieId = 6, GenresGenreId = 1 },
			new { MoviesMovieId = 6, GenresGenreId = 4 },
			new { MoviesMovieId = 6, GenresGenreId = 6 },
			//Movie 7
			new { MoviesMovieId = 7, GenresGenreId = 4 },
			new { MoviesMovieId = 7, GenresGenreId = 9 },
			new { MoviesMovieId = 7, GenresGenreId = 10 },
			//Movie 8
			new { MoviesMovieId = 8, GenresGenreId = 1 },
			new { MoviesMovieId = 8, GenresGenreId = 2 },
			new { MoviesMovieId = 8, GenresGenreId = 11 },
			//Movie 9
			new { MoviesMovieId = 9, GenresGenreId = 1 },
			new { MoviesMovieId = 9, GenresGenreId = 2 },
			new { MoviesMovieId = 9, GenresGenreId = 10 },
			//Movie 10
			new { MoviesMovieId = 10, GenresGenreId = 1 },
			new { MoviesMovieId = 10, GenresGenreId = 2 },
			new { MoviesMovieId = 10, GenresGenreId = 10 },
			//Movie 11
			new { MoviesMovieId = 11, GenresGenreId = 5 },
			new { MoviesMovieId = 11, GenresGenreId = 4 },
			new { MoviesMovieId = 11, GenresGenreId = 6 },
			//Movie 12
			new { MoviesMovieId = 12, GenresGenreId = 1 },
			new { MoviesMovieId = 12, GenresGenreId = 6 },
			new { MoviesMovieId = 12, GenresGenreId = 8 },
			//Movie 13
			new { MoviesMovieId = 13, GenresGenreId = 5 },
			new { MoviesMovieId = 13, GenresGenreId = 6 },
			new { MoviesMovieId = 13, GenresGenreId = 10 },
			//Movie 14
			new { MoviesMovieId = 14, GenresGenreId = 1 },
			new { MoviesMovieId = 14, GenresGenreId = 2 },
			new { MoviesMovieId = 14, GenresGenreId = 11 },
			//Movie 15
			new { MoviesMovieId = 15, GenresGenreId = 1 },
			new { MoviesMovieId = 15, GenresGenreId = 4 },
			new { MoviesMovieId = 15, GenresGenreId = 10 },
			//Movie 16
			new { MoviesMovieId = 16, GenresGenreId = 1 },
			new { MoviesMovieId = 16, GenresGenreId = 4 },
			new { MoviesMovieId = 16, GenresGenreId = 6 },
			//Movie 17
			new { MoviesMovieId = 17, GenresGenreId = 1 },
			new { MoviesMovieId = 17, GenresGenreId = 4 },
			new { MoviesMovieId = 17, GenresGenreId = 6 },
			//Movie 18
			new { MoviesMovieId = 18, GenresGenreId = 3 },
			//Movie 19
			new { MoviesMovieId = 19, GenresGenreId = 3 },
			new { MoviesMovieId = 19, GenresGenreId = 4 },
			//Movie 20
			new { MoviesMovieId = 20, GenresGenreId = 1 },
			new { MoviesMovieId = 20, GenresGenreId = 4 },
			new { MoviesMovieId = 20, GenresGenreId = 6 },
			//Movie 21
			new { MoviesMovieId = 21, GenresGenreId = 1 },
			new { MoviesMovieId = 21, GenresGenreId = 10 },
			//Movie 22
			new { MoviesMovieId = 22, GenresGenreId = 2 },
			new { MoviesMovieId = 22, GenresGenreId = 11 },
			//Movie 23
			new { MoviesMovieId = 23, GenresGenreId = 1 },
			new { MoviesMovieId = 23, GenresGenreId = 3 },
			new { MoviesMovieId = 23, GenresGenreId = 4 },
			//Movie 24
			new { MoviesMovieId = 24, GenresGenreId = 1 },
			new { MoviesMovieId = 24, GenresGenreId = 2 },
			new { MoviesMovieId = 24, GenresGenreId = 10 }
		};
		
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Movie>().HasData(DefaultMovies());
			builder.Entity<Genre>().HasData(DefaultGenres());

			builder.Entity<Movie>()
				.HasMany(m => m.Genres)
				.WithMany(g => g.Movies)
				.UsingEntity(x => x.HasData(DefaultMoviesGenres()));

			base.OnModelCreating(builder);
		}
	}
}
