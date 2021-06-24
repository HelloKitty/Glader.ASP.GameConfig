using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Represents the result of a successful
	/// configuration.
	/// </summary>
	[JsonObject]
	public sealed class ConfigurationDataResult : IConfigurationSourceable
	{
		/// <summary>
		/// The source of the configuration.
		/// </summary>
		[JsonProperty]
		public ConfigurationSourceType Source { get; private set; }

		/// <summary>
		/// Represents a generic binary blob of serialized config data.
		/// This keeps game data serialization generic to the library
		/// as it's impossible to generally model this.
		/// </summary>
		[JsonProperty]
		public byte[] Data { get; private set; } = Array.Empty<byte>();

		public ConfigurationDataResult(ConfigurationSourceType source, byte[] data)
		{
			if (!Enum.IsDefined(typeof(ConfigurationSourceType), source)) throw new InvalidEnumArgumentException(nameof(source), (int) source, typeof(ConfigurationSourceType));
			Source = source;
			Data = data ?? throw new ArgumentNullException(nameof(data));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		[JsonConstructor]
		public ConfigurationDataResult()
		{
			
		}
	}
}
