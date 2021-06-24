using System;
using System.Collections.Generic;
using System.Text;
using Glader.Essentials;

namespace Glader.ASP.GameConfig
{
	public interface ICharacterGameConfigurationRepository<TConfigType> : IGenericRepositoryCrudable<GameConfigurationKey<TConfigType>, CharacterGameConfiguration<TConfigType>> 
		where TConfigType : Enum
	{

	}
}
