using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Shared keybind data model.
	/// </summary>
	[Owned]
	public sealed class KeybindData
	{
		/// <summary>
		/// Binary blob representing the keybindings data.
		/// </summary>
		[Required]
		public byte[] Data { get; set; } = Array.Empty<byte>();

		public KeybindData(byte[] data)
		{
			Data = data ?? throw new ArgumentNullException(nameof(data));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public KeybindData()
		{
			
		}
	}
}
