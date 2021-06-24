using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Glader.Essentials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Glader.ASP.GameConfig
{
	//Cannot use [Controller] doesn't work with generics
	[Route("api/GameConfig")]
	public sealed class GameConfigController<TConfigType> : AuthorizationReadyController, IGameConfigurationService<TConfigType>
		where TConfigType : Enum
	{
		private IAccountGameConfigurationRepository<TConfigType> AccountConfigRepository { get; }

		private ICharacterGameConfigurationRepository<TConfigType> CharacterConfigRepository { get; }

		public GameConfigController(IClaimsPrincipalReader claimsReader, 
			ILogger<AuthorizationReadyController> logger, 
			IAccountGameConfigurationRepository<TConfigType> accountConfigRepository, 
			ICharacterGameConfigurationRepository<TConfigType> characterConfigRepository) 
			: base(claimsReader, logger)
		{
			AccountConfigRepository = accountConfigRepository ?? throw new ArgumentNullException(nameof(accountConfigRepository));
			CharacterConfigRepository = characterConfigRepository ?? throw new ArgumentNullException(nameof(characterConfigRepository));
		}

		/// <inheritdoc />
		[RequiresAuthentication]
		[AuthorizeJwt]
		[HttpPut]
		public async Task UpdateGameConfigAsync([FromBody] GameConfigurationUpdateRequest<TConfigType> request, CancellationToken token = default)
		{
			int ownershipId = RetrieveOwnershipId(request.Source);

			if(!await ContainsConfigEntryAsync(request.Source, request.ConfigType, ownershipId, token))
				if(!await CreateConfigEntryAsync(request, ownershipId, token))
					throw new InvalidOperationException($"Failed to create Config for Source: {request.Source} Id: {ownershipId}");

			await UpdateConfigEntryAsync(request, ownershipId, token);
		}

		/// <inheritdoc />
		[RequiresAuthentication]
		[AuthorizeJwt]
		[HttpGet("{source}/{config}")]
		public async Task<ResponseModel<ConfigurationDataResult, GameConfigQueryResponseCode>> RetrieveConfigAsync([FromRoute(Name = "source")] ConfigurationSourceType source, [FromRoute(Name = "config")] TConfigType configType, CancellationToken token = default)
		{
			int ownershipId = RetrieveOwnershipId(source);

			if(!await ContainsConfigEntryAsync(source, configType, ownershipId, token))
				return Failure<ConfigurationDataResult, GameConfigQueryResponseCode>(GameConfigQueryResponseCode.ContentNotFound);

			var entry = await RetrieveConfigEntryAsync(source, configType, ownershipId, token);

			return Success<ConfigurationDataResult, GameConfigQueryResponseCode>(new ConfigurationDataResult(source, entry.Data.Data));
		}

		private int RetrieveOwnershipId(ConfigurationSourceType source)
		{
			return source == ConfigurationSourceType.Account ? ClaimsReader.GetAccountId<int>(User) : ClaimsReader.GetSubAccountId<int>(User);
		}

		private async Task UpdateConfigEntryAsync(GameConfigurationUpdateRequest<TConfigType> request, int ownershipId, CancellationToken token = default)
		{
			if(request == null) throw new ArgumentNullException(nameof(request));

			switch(request.Source)
			{
				case ConfigurationSourceType.Account:
				{
					var entry = await AccountConfigRepository.RetrieveAsync(new GameConfigurationKey<TConfigType>(ownershipId, request.ConfigType), token);
					entry.Data = new GameConfigData(request.Data);
					await AccountConfigRepository.UpdateAsync(new GameConfigurationKey<TConfigType>(ownershipId, request.ConfigType), entry, token);
					return;
				}
				case ConfigurationSourceType.Character:
				{
					var entry = await CharacterConfigRepository.RetrieveAsync(new GameConfigurationKey<TConfigType>(ownershipId, request.ConfigType), token);
					entry.Data = new GameConfigData(request.Data);
					await CharacterConfigRepository.UpdateAsync(new GameConfigurationKey<TConfigType>(ownershipId, request.ConfigType), entry, token);
					return;
				}
				default:
					throw new ArgumentOutOfRangeException(nameof(request.Source), request.Source, null);
			}
		}

		private async Task<bool> CreateConfigEntryAsync(GameConfigurationUpdateRequest<TConfigType> request, int ownershipId, CancellationToken token = default)
		{
			if (request == null) throw new ArgumentNullException(nameof(request));

			switch(request.Source)
			{
				case ConfigurationSourceType.Account:
					return await AccountConfigRepository.TryCreateAsync(new AccountGameConfiguration<TConfigType>(ownershipId, new GameConfigData(request.Data), request.ConfigType), token);
				case ConfigurationSourceType.Character:
					return await CharacterConfigRepository.TryCreateAsync(new CharacterGameConfiguration<TConfigType>(ownershipId, new GameConfigData(request.Data), request.ConfigType), token);
				default:
					throw new ArgumentOutOfRangeException(nameof(request.Source), request.Source, null);
			}
		}

		private async Task<IGameConfigurationTable<TConfigType>> RetrieveConfigEntryAsync(ConfigurationSourceType source, TConfigType configType, int ownershipId, CancellationToken token = default)
		{
			if(configType == null) throw new ArgumentNullException(nameof(configType));
			if(!Enum.IsDefined(typeof(ConfigurationSourceType), source)) throw new InvalidEnumArgumentException(nameof(source), (int)source, typeof(ConfigurationSourceType));

			switch(source)
			{
				case ConfigurationSourceType.Account:
					return await AccountConfigRepository.RetrieveAsync(new GameConfigurationKey<TConfigType>(ownershipId, configType), token);
				case ConfigurationSourceType.Character:
					return await CharacterConfigRepository.RetrieveAsync(new GameConfigurationKey<TConfigType>(ownershipId, configType), token);
				default:
					throw new ArgumentOutOfRangeException(nameof(source), source, null);
			}
		}

		private async Task<bool> ContainsConfigEntryAsync(ConfigurationSourceType source, TConfigType configType, int ownershipId, CancellationToken token = default)
		{
			if (configType == null) throw new ArgumentNullException(nameof(configType));
			if (!Enum.IsDefined(typeof(ConfigurationSourceType), source)) throw new InvalidEnumArgumentException(nameof(source), (int) source, typeof(ConfigurationSourceType));

			switch(source)
			{
				case ConfigurationSourceType.Account:
					return !await AccountConfigRepository.ContainsAsync(new GameConfigurationKey<TConfigType>(ownershipId, configType), token);
				case ConfigurationSourceType.Character:
					return !await CharacterConfigRepository.ContainsAsync(new GameConfigurationKey<TConfigType>(ownershipId, configType), token);
				default:
					throw new ArgumentOutOfRangeException(nameof(source), source, null);
			}
		}
	}
}
