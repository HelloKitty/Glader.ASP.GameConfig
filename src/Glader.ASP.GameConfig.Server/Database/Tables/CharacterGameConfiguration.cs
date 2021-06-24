using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Character specific Game Config table model. Represents the configuration for Character-wide config
	/// and is linked to a character.
	/// </summary>
	[Table("gameconfig_character")]
	public class CharacterGameConfiguration<TConfigType> : IGameConfigurationTable<TConfigType>
		where TConfigType : Enum
	{
		/// <summary>
		/// The account id the configuration data is linked ot.
		/// </summary>
		[Column("id")]
		public int CharacterId { get; internal set; }

		[NotMapped]
		[IgnoreDataMember]
		int IGameConfigurationTable<TConfigType>.OwnerId => CharacterId;

		/// <summary>
		/// The type of the configuration.
		/// </summary>
		[Required]
		[Column("type")]
		public TConfigType Type { get; internal set; }

		[IgnoreDataMember]
		[ForeignKey(nameof(Type))]
		public virtual GameConfigurationType<TConfigType> Config { get; private set; }

		/// <summary>
		/// The config data.
		/// </summary>
		[Required]
		[Column("data")]
		public GameConfigData Data { get; internal set; }

		public CharacterGameConfiguration(int characterId, GameConfigData data, TConfigType type)
		{
			if (characterId < 0) throw new ArgumentOutOfRangeException(nameof(characterId));
			CharacterId = characterId;
			Data = data ?? throw new ArgumentNullException(nameof(data));
			Type = type;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CharacterGameConfiguration()
		{

		}
	}
}
