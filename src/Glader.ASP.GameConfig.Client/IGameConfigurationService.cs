using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Glader.Essentials;
using Refit;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// Contract for REST service that provides
	/// configuration data.
	/// </summary>
	[Headers("User-Agent: Glader")]
	public interface IGameConfigurationService<TConfigType> 
		where TConfigType : Enum
	{
		/// <summary>
		/// Retrieves the keybind configuration with the specified source type and config type.
		/// </summary>
		/// <param name="source">The source for the configuration.</param>
		/// <param name="configType">The config type.</param>
		/// <param name="token">Cancel token.</param>
		/// <returns>Query result.</returns>
		[RequiresAuthentication]
		[Get("/api/GameConfig/{source}/{config}")]
		Task<ResponseModel<KeybindConfigurationResult, GameConfigQueryResponseCode>> RetrieveConfigAsync([AliasAs("source")] ConfigurationSourceType source, [AliasAs("config")] TConfigType configType, CancellationToken token = default);

		/// <summary>
		/// Updates/Creates the keybind configuration for the account.
		/// </summary>
		/// <param name="request">The keybind configuration update request. Request source MUST be set to Account.</param>
		/// <param name="token">Cancel token.</param>
		/// <returns>OK if successfully stored.</returns>
		[RequiresAuthentication]
		[Put("/api/GameConfig")]
		Task UpdateGameConfigAsync([JsonBody] GameConfigurationUpdateRequest<TConfigType> request, CancellationToken token = default);
	}
}
