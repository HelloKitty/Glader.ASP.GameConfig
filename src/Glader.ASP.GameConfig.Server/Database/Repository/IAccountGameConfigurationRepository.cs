using System;
using System.Collections.Generic;
using System.Text;
using Glader.Essentials;

namespace Glader.ASP.GameConfig
{
	public interface IAccountGameConfigurationRepository<TConfigType> : IGenericRepositoryCrudable<GameConfigurationKey<TConfigType>, AccountGameConfiguration<TConfigType>> 
		where TConfigType : Enum
	{

	}
}
