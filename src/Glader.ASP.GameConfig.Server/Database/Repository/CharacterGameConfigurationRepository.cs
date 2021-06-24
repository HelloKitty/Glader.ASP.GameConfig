using System;
using System.Collections.Generic;
using System.Text;
using Glader.Essentials;
using Microsoft.EntityFrameworkCore;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// EF-Core Database Backed <see cref="ICharacterGameConfigurationRepository{TConfigType}"/>.
	/// </summary>
	public sealed class CharacterGameConfigurationRepository<TConfigType> : GameConfigurationRepository<TConfigType, CharacterGameConfiguration<TConfigType>>, ICharacterGameConfigurationRepository<TConfigType> 
		where TConfigType : Enum
	{
		public CharacterGameConfigurationRepository(GameConfigurationDatabaseContext<TConfigType> context)
			: base(context)
		{

		}
	}
}
