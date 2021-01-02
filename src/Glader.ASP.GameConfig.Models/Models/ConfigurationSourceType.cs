using System;
using System.Collections.Generic;
using System.Text;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Enumeration of source types for a configuration
	/// data.
	/// </summary>
	public enum ConfigurationSourceType
	{
		/// <summary>
		/// Default generated configuration data.
		/// </summary>
		Default = 0,

		/// <summary>
		/// Configuration data for the linked source of an account.
		/// </summary>
		Account = 1,

		/// <summary>
		/// Configuration data linked to a sub-account (character in games).
		/// </summary>
		Character = 2,
	}
}
