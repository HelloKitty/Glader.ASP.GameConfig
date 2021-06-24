using System;
using System.Collections.Generic;
using System.Text;
using Glader.Essentials;
using Microsoft.EntityFrameworkCore;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// EF-Core Database Backed <see cref="IAccountGameConfigurationRepository{TConfigType}"/>.
	/// </summary>
	public sealed class AccountGameConfigurationRepository<TConfigType> : GameConfigurationRepository<TConfigType, AccountGameConfiguration<TConfigType>>, IAccountGameConfigurationRepository<TConfigType> 
		where TConfigType : Enum
	{
		public AccountGameConfigurationRepository(GameConfigurationDatabaseContext<TConfigType> context)
			: base(context)
		{

		}
	}
}
