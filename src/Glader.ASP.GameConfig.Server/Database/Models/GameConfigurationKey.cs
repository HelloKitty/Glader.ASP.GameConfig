using System;
using System.Collections.Generic;
using System.Text;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Configuration key model.
	/// </summary>
	/// <typeparam name="TConfigType">The configuration enum type.</typeparam>
	public record GameConfigurationKey<TConfigType>(int Id, TConfigType Config) 
		where TConfigType : Enum;
}
