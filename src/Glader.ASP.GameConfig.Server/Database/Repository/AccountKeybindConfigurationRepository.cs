using System;
using System.Collections.Generic;
using System.Text;
using Glader.Essentials;
using Microsoft.EntityFrameworkCore;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// EF-Core Database Backed <see cref="IAccountKeybindConfigurationRepository"/>.
	/// </summary>
	public sealed class AccountKeybindConfigurationRepository : GeneralGenericCrudRepositoryProvider<int, AccountKeybindConfiguration>, IAccountKeybindConfigurationRepository
	{
		public AccountKeybindConfigurationRepository(GameConfigurationDatabaseContext context) 
			: base(context.AccountKeybindConfiguration, context)
		{

		}
	}
}
