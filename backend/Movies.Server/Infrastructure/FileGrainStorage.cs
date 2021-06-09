using Orleans;
using System;
using Orleans.Storage;
using Orleans.Runtime;
using System.Threading.Tasks;
using System.Threading;
using Orleans.Serialization;
using Newtonsoft.Json;
using Orleans.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using Movies.Contracts;

namespace Movies.Server.Infrastructure
{
	public class FileGrainStorageOptions
	{
		public string RootDirectory { get; set; }
	}

	public class FileGrainStorage : IGrainStorage, ILifecycleParticipant<ISiloLifecycle>
	{
		private readonly string _storageName;
		private readonly FileGrainStorageOptions _options;
		private readonly ClusterOptions _clusterOptions;
		private readonly IGrainFactory _grainFactory;
		private readonly ITypeResolver _typeResolver;
		private JsonSerializerSettings _jsonSettings;

		public FileGrainStorage(string storageName, FileGrainStorageOptions options, IOptions<ClusterOptions> clusterOptions, IGrainFactory grainFactory, ITypeResolver typeResolver)
		{
			_storageName = storageName;
			_options = options;
			_clusterOptions = clusterOptions.Value;
			_grainFactory = grainFactory;
			_typeResolver = typeResolver;
		}

		public Task ClearStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
		{
			var fName = GetKeyString(grainType, grainReference);
			var path = Path.Combine(_options.RootDirectory, fName);

			var fileInfo = new FileInfo(path);
			if (fileInfo.Exists)
			{
				if (fileInfo.LastWriteTimeUtc.ToString() != grainState.ETag)
				{
					throw new InconsistentStateException($"Version conflict (ClearState): ServiceId={_clusterOptions.ServiceId} ProviderName={_storageName} GrainType={grainType} GrainReference={grainReference.ToKeyString()}.");
				}

				grainState.ETag = null;
				grainState.State = Activator.CreateInstance(grainState.State.GetType());
				fileInfo.Delete();
			}

			return Task.CompletedTask;
		}

		public async Task ReadStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
		{
			using(StreamReader r = new StreamReader("movies.json"))
			{
				var storedData = await r.ReadToEndAsync();
				grainState.State = JsonConvert.DeserializeObject<MovieState>(storedData);
			}
		}

		public async Task WriteStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
		{
			var storedData = JsonConvert.SerializeObject(grainState.State, Formatting.Indented);
			using(StreamWriter file = File.CreateText("movies.json"))
			{
				await file.WriteAsync(storedData);
			}
		}

		public void Participate(ISiloLifecycle lifecycle) => lifecycle.Subscribe(OptionFormattingUtilities.Name<FileGrainStorage>(_storageName), ServiceLifecycleStage.ApplicationServices, Init);

		private Task Init(CancellationToken ct)
		{
			// Settings could be made configurable from Options.
			_jsonSettings = OrleansJsonSerializer.UpdateSerializerSettings(OrleansJsonSerializer.GetDefaultSerializerSettings(_typeResolver, _grainFactory), false, false, null);

			var directory = new DirectoryInfo(_options.RootDirectory);
			//if (!directory.Exists)
			//	directory.Create();

			return Task.CompletedTask;
		}

		private string GetKeyString(string grainType, GrainReference grainReference) => $"{_clusterOptions.ServiceId}.{grainReference.ToKeyString()}.{grainType}";
	}
}
