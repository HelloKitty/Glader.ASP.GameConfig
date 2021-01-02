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
	public sealed class KeybindConfigurationResult
	{
		/// <summary>
		/// The source of the configuration.
		/// </summary>
		[JsonProperty]
		public ConfigurationSourceType Source { get; private set; }

		/// <summary>
		/// Represents a generic binary blob of serialized keybinds data.
		/// This keeps keybind serialization generic to the library
		/// as it's impossible to generally model this.
		/// </summary>
		[JsonProperty]
		public byte[] KeybindData { get; private set; } = Array.Empty<byte>();

		public KeybindConfigurationResult(ConfigurationSourceType source, byte[] keybindData)
		{
			if (!Enum.IsDefined(typeof(ConfigurationSourceType), source)) throw new InvalidEnumArgumentException(nameof(source), (int) source, typeof(ConfigurationSourceType));
			Source = source;
			KeybindData = keybindData ?? throw new ArgumentNullException(nameof(keybindData));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		[JsonConstructor]
		public KeybindConfigurationResult()
		{
			
		}
	}
}
