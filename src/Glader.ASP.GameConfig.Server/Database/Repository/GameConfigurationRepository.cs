using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Glader.Essentials;
using Microsoft.EntityFrameworkCore;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// EF-Core Database Backed <see cref="IGenericRepositoryCrudable{TKey,TModel}"/> for <see cref="GameConfigurationKey{TConfigType}"/> keys and <typeparamref name="TConfigurationModelType"/>
	/// models that implement <see cref="IGameConfigurationTable{TConfigType}"/>.
	/// </summary>
	public class GameConfigurationRepository<TConfigType, TConfigurationModelType> : GeneralGenericCrudRepositoryProvider<GameConfigurationKey<TConfigType>, TConfigurationModelType>
		where TConfigType : Enum
		where TConfigurationModelType : class, IGameConfigurationTable<TConfigType>
	{
		public GameConfigurationRepository(DbContext context)
			: base(context.Set<TConfigurationModelType>(), context)
		{

		}

		/// <inheritdoc />
		public override async Task<TConfigurationModelType> RetrieveAsync(GameConfigurationKey<TConfigType> key, CancellationToken token = default, bool includeNavigationProperties = false)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));
			return await ModelSet.FindAsync(new object[] { key.Id, key.Config }, token);
		}
	}
}
