using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Request model that updates the keybinding gameconfig.
	/// </summary>
	[JsonObject]
	public sealed class KeybindConfigurationUpdateRequest : IConfigurationSourceable
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

		public KeybindConfigurationUpdateRequest(byte[] keybindData)
		{
			//TODO: How should character specific config work?
			//Cannot remotely update default, and character requires additional information
			//so it's a request model. Maybe?
			Source = ConfigurationSourceType.Account;
			KeybindData = keybindData ?? throw new ArgumentNullException(nameof(keybindData));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		[JsonConstructor]
		public KeybindConfigurationUpdateRequest()
		{

		}
	}
}
