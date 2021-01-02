using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// keybindings table model. Represents the configuration for keybinds
	/// and is linked to an account.
	/// </summary>
	[Table("keybindings")]
	public class AccountKeybindConfiguration
	{
		/// <summary>
		/// The account id the configuration data is linked ot.
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("id")]
		public int AccountId { get; internal set; }

		/// <summary>
		/// The keybinding data.
		/// </summary>
		[Required]
		[Column("data")]
		public KeybindData Data { get; internal set; }

		public AccountKeybindConfiguration(int accountId, KeybindData data)
		{
			if (accountId < 0) throw new ArgumentOutOfRangeException(nameof(accountId));
			AccountId = accountId;
			Data = data ?? throw new ArgumentNullException(nameof(data));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public AccountKeybindConfiguration()
		{
			
		}
	}
}
