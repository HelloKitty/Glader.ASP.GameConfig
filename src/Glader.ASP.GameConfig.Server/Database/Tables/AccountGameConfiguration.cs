using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Account-wide Game Config table model. Represents the configuration for Account-wide config
	/// and is linked to an account.
	/// </summary>
	[Table("gameconfig_account")]
	public class AccountGameConfiguration<TConfigType> : IGameConfigurationTable<TConfigType>
		where TConfigType : Enum
	{
		/// <summary>
		/// The account id the configuration data is linked ot.
		/// </summary>
		[Column("id")]
		public int AccountId { get; private set; }

		[NotMapped]
		[IgnoreDataMember]
		int IGameConfigurationTable<TConfigType>.OwnerId => AccountId;

		/// <summary>
		/// The type of the configuration.
		/// </summary>
		[Required]
		[Column("type")]
		public TConfigType Type { get; private set; }

		[IgnoreDataMember]
		[ForeignKey(nameof(Type))]
		public virtual GameConfigurationType<TConfigType> Config { get; private set; }

		/// <summary>
		/// The config data.
		/// </summary>
		[Required]
		[Column("data")]
		public GameConfigData Data { get; internal set; }

		public AccountGameConfiguration(int accountId, GameConfigData data, TConfigType type)
		{
			if (accountId < 0) throw new ArgumentOutOfRangeException(nameof(accountId));
			AccountId = accountId;
			Data = data ?? throw new ArgumentNullException(nameof(data));
			Type = type;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public AccountGameConfiguration()
		{

		}
	}
}
