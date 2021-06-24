using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Contract for tables that store game configuration.
	/// </summary>
	/// <typeparam name="TConfigType">The config type.</typeparam>
	public interface IGameConfigurationTable<out TConfigType>
		where TConfigType : Enum
	{
		[NotMapped]
		[IgnoreDataMember]
		public int OwnerId { get; }

		/// <summary>
		/// The type of the configuration.
		/// </summary>
		[Required]
		[Column("type")]
		public TConfigType Type { get; }

		/// <summary>
		/// The config data.
		/// </summary>
		[Required]
		[Column("data")]
		public GameConfigData Data { get; }
	}
}
