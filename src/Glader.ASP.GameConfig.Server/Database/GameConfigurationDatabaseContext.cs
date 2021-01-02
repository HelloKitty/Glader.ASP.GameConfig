using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// <see cref="DbContext"/> implementation for Game Configuration tables.
	/// </summary>
	public sealed class GameConfigurationDatabaseContext : DbContext
	{
		//Tables with no suffic indicate it's global/account wide.
		public DbSet<AccountKeybindConfiguration> AccountKeybindConfiguration { get; set; }

		public GameConfigurationDatabaseContext(DbContextOptions<GameConfigurationDatabaseContext> options)
			: base(options)
		{

		}

		public GameConfigurationDatabaseContext()
		{

		}

		/// <inheritdoc />
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//This produces a much easier to understand table.
			modelBuilder.Entity<AccountKeybindConfiguration>()
				.OwnsOne(o => o.Data, sa =>
				{
					sa.Property(p => p.Data).HasColumnName("data");
				});
		}
	}
}
