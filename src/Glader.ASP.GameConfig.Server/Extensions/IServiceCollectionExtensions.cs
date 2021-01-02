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
		/// Registers a <see cref="GameConfigurationDatabaseContext"/> and <see cref="IAccountKeybindConfigurationRepository"/>
		/// in the provided <see cref="services"/>.
		/// </summary>
		/// <param name="services">Service container.</param>
		/// <param name="optionsAction">The DB context options action.</param>
		/// <returns></returns>
		public static IServiceCollection RegisterGameConfigDatabase(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));
			if (optionsAction == null) throw new ArgumentNullException(nameof(optionsAction));

			//DefaultServiceEndpointRepository : IServiceEndpointRepository
			services.AddTransient<IAccountKeybindConfigurationRepository, AccountKeybindConfigurationRepository>();
			services.AddDbContext<GameConfigurationDatabaseContext>(optionsAction);

			//Example:
			//services.AddDbContext<ServiceDiscoveryDatabaseContext>(builder => { builder.UseMySql("server=127.0.0.1;port=3306;Database=guardians.global;Uid=root;Pwd=test;"); });
			return services;
		}
	}
}
