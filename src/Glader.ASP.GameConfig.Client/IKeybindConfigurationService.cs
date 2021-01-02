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
	/// services discovery endpoints.
	/// </summary>
	[Headers("User-Agent: Glader")]
	public interface IKeybindConfigurationService
	{
		/// <summary>
		/// Retrieves the keybind configuration from the account if it exists.
		/// </summary>
		/// <param name="token">Cancel token.</param>
		/// <returns>Query result.</returns>
		[RequiresAuthentication]
		[Get("/api/KeybindConfig/account")]
		Task<ResponseModel<KeybindConfigurationResult, GameConfigQueryResponseCode>> RetrieveAccountBindsAsync(CancellationToken token = default);

		/// <summary>
		/// Updates/Creates the keybind configuration for the account.
		/// </summary>
		/// <param name="request">The keybind configuration update request. Request source MUST be set to Account.</param>
		/// <param name="token">Cancel token.</param>
		/// <returns>OK if successfully stored.</returns>
		[RequiresAuthentication]
		[Put("/api/KeybindConfig/account")]
		Task UpdateAccountBindsAsync([JsonBody] KeybindConfigurationUpdateRequest request, CancellationToken token = default);
	}
}
