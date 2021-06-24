using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Request model that updates the specified gameconfig.
	/// </summary>
	[JsonObject]
	public sealed class GameConfigurationUpdateRequest<TConfigType> : IConfigurationSourceable
		where TConfigType : Enum
	{
		/// <summary>
		/// The source of the configuration.
		/// </summary>
		[JsonProperty]
		public ConfigurationSourceType Source { get; private set; }

		/// <summary>
		/// Represents the configuration type.
		/// </summary>
		[JsonProperty]
		public TConfigType ConfigType { get; private set; }

		/// <summary>
		/// Represents a generic binary blob of serialized data.
		/// This keeps GameConfig serialization generic to the library
		/// as it's impossible to generally model this.
		/// </summary>
		[JsonProperty]
		public byte[] KeybindData { get; private set; } = Array.Empty<byte>();

		public GameConfigurationUpdateRequest(ConfigurationSourceType source, TConfigType configType, byte[] data)
		{
			if (!Enum.IsDefined(typeof(ConfigurationSourceType), source)) throw new InvalidEnumArgumentException(nameof(source), (int) source, typeof(ConfigurationSourceType));

			//TODO: How should character specific config work?
			//Cannot remotely update default, and character requires additional information
			//so it's a request model. Maybe?
			Source = source;
			ConfigType = configType;
			KeybindData = data ?? throw new ArgumentNullException(nameof(data));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		[JsonConstructor]
		public GameConfigurationUpdateRequest()
		{

		}
	}
}
