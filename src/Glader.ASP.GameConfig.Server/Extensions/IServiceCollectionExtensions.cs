using System;
using System.Collections.Generic;
using System.Text;
using Glader.ASP.GameConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Glader.ASP.GameConfig
{
	public static class IServiceCollectionExtensions
	{
		/// <summary>
		/// Registers a <see cref="GameConfigurationDatabaseContext{TConfigType}"/> and <see cref="GameConfigurationRepository{TConfigType,TConfigurationModelType}"/>
		/// in the provided <see cref="services"/>.
		/// </summary>
		/// <param name="services">Service container.</param>
		/// <param name="optionsAction">The DB context options action.</param>
		/// <returns></returns>
		public static IServiceCollection RegisterGameConfigDatabase<TConfigType>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction) 
			where TConfigType : Enum
		{
			return RegisterGameConfigDatabase<GameConfigurationDatabaseContext<TConfigType>, TConfigType>(services, optionsAction);
		}

		/// <summary>
		/// Registers a <see cref="GameConfigurationDatabaseContext{TConfigType}"/> of the specificed generic type and <see cref="GameConfigurationRepository{TConfigType,TConfigurationModelType}"/>
		/// in the provided <see cref="services"/>.
		/// </summary>
		/// <param name="services">Service container.</param>
		/// <param name="optionsAction">The DB context options action.</param>
		/// <returns></returns>
		public static IServiceCollection RegisterGameConfigDatabase<TDatabaseContextType, TConfigType>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
			where TDatabaseContextType : GameConfigurationDatabaseContext<TConfigType> 
			where TConfigType : Enum
		{
			if(services == null) throw new ArgumentNullException(nameof(services));
			if(optionsAction == null) throw new ArgumentNullException(nameof(optionsAction));

			//DefaultServiceEndpointRepository : IServiceEndpointRepository
			services.AddTransient<IAccountGameConfigurationRepository<TConfigType>, AccountGameConfigurationRepository<TConfigType>>();
			services.AddTransient<ICharacterGameConfigurationRepository<TConfigType>, CharacterGameConfigurationRepository<TConfigType>>();
			services.AddDbContext<TDatabaseContextType>(optionsAction);

			//Example:
			//services.AddDbContext<ServiceDiscoveryDatabaseContext>(builder => { builder.UseMySql("server=127.0.0.1;port=3306;Database=guardians.global;Uid=root;Pwd=test;"); });
			return services;
		}
	}
}
