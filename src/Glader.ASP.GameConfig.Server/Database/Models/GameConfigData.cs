using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Shared config data model.
	/// </summary>
	[Owned]
	public sealed class GameConfigData
	{
		/// <summary>
		/// Binary blob representing the config data.
		/// </summary>
		[Required]
		public byte[] Data { get; set; } = Array.Empty<byte>();

		public GameConfigData(byte[] data)
		{
			Data = data ?? throw new ArgumentNullException(nameof(data));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GameConfigData()
		{
			
		}
	}
}
