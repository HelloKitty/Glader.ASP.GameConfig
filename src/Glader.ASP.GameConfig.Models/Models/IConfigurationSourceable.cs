using System;
using System.Collections.Generic;
using System.Text;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Contract for models that can be linked a <see cref="ConfigurationSourceType"/>.
	/// </summary>
	public interface IConfigurationSourceable
	{
		/// <summary>
		/// The source of the configuration.
		/// </summary>
		ConfigurationSourceType Source { get; }
	}
}
