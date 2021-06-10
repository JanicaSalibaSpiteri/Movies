using GraphiQl;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movies.Contracts;
using Movies.Core;
using Movies.GrainClients;
using Movies.Server.Gql.App;
using Movies.Server.Infrastructure;
using Newtonsoft.Json;
using System.IO;

namespace Movies.Server
{
	public class ApiStartup
	{
		private readonly IConfiguration _configuration;
		private readonly IAppInfo _appInfo;

		public ApiStartup(
			IConfiguration configuration,
			IAppInfo appInfo
		)
		{
			_configuration = configuration;
			_appInfo = appInfo;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCustomAuthentication();
			services.AddCors(o => o.AddPolicy("TempCorsPolicy", builder =>
			{
				builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
			}));

			// note: to fix graphql for .net core 3
			services.Configure<KestrelServerOptions>(options =>
			{
				options.AllowSynchronousIO = true;
			});

			services.AddAppClients();
			services.AddAppGraphQL();
			services.AddControllers()
			.AddNewtonsoftJson();

			services.AddMemoryCache();

			services.AddDbContext<MovieContext>(options =>
			{
				options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app,
			IWebHostEnvironment env,
			IMemoryCache cache
		)
		{
			app.UseCors("TempCorsPolicy");

			// add http for Schema at default url /graphql
			app.UseGraphQL<ISchema>();

			// use graphql-playground at default url /ui/playground
			app.UseGraphQLPlayground();

			//app.UseGraphQLEndPoint<AppSchema>("/graphql");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseGraphiQl();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			//Loading data in memory cache
			var entryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove);

			var movies = JsonConvert.DeserializeObject<MovieState>(File.ReadAllText("movies.json"));
			cache.Set("AllMovies", movies, entryOptions);
		}
	}
}