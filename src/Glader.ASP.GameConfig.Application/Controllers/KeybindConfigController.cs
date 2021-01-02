using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Glader.Essentials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Glader.ASP.GameConfig
{
	[Route("api/[controller]")]
	public sealed class KeybindConfigController : AuthorizationReadyController, IKeybindConfigurationService
	{
		private IAccountKeybindConfigurationRepository KeybindRepository { get; }

		public KeybindConfigController(IClaimsPrincipalReader claimsReader, 
			ILogger<AuthorizationReadyController> logger, 
			IAccountKeybindConfigurationRepository keybindRepository) 
			: base(claimsReader, logger)
		{
			KeybindRepository = keybindRepository ?? throw new ArgumentNullException(nameof(keybindRepository));
		}

		[RequiresAuthentication]
		[AuthorizeJwt]
		[HttpGet("account")]
		public async Task<ResponseModel<KeybindConfigurationResult, GameConfigQueryResponseCode>> RetrieveAccountBindsAsync(CancellationToken token = default)
		{
			int accountId = ClaimsReader.GetAccountId<int>(User);

			if (!await KeybindRepository.ContainsAsync(accountId, token))
				return Failure<KeybindConfigurationResult, GameConfigQueryResponseCode>(GameConfigQueryResponseCode.ContentNotFound);

			AccountKeybindConfiguration data = await KeybindRepository.RetrieveAsync(accountId, token);

			return Success<KeybindConfigurationResult, GameConfigQueryResponseCode>(new KeybindConfigurationResult(ConfigurationSourceType.Account, data.Data.Data));
		}

		[RequiresAuthentication]
		[AuthorizeJwt]
		[HttpPut("account")]
		public async Task UpdateAccountBindsAsync(KeybindConfigurationUpdateRequest request, CancellationToken token = default)
		{
			int accountId = ClaimsReader.GetAccountId<int>(User);

			if (!await KeybindRepository.ContainsAsync(accountId, token))
			{
				if (!await KeybindRepository.TryCreateAsync(new AccountKeybindConfiguration(accountId, new KeybindData(request.KeybindData)), token))
					throw new InvalidOperationException($"Failed to create Keybind Config for Id: {accountId}");
			}

			AccountKeybindConfiguration data = await KeybindRepository.RetrieveAsync(accountId, token);
			data.Data.Data = request.KeybindData;

			await KeybindRepository.UpdateAsync(accountId, data, token);
		}
	}
}
