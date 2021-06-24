using System;
using System.Collections.Generic;
using System.Text;
using Glader.Essentials;
using Microsoft.EntityFrameworkCore;

namespace Glader.ASP.GameConfig
{
	/// <summary>
	/// <see cref="DbContext"/> implementation for Game Configuration tables.
	/// </summary>
	public class GameConfigurationDatabaseContext<TConfigType> : DbContext 
		where TConfigType : Enum
	{
		public DbSet<AccountGameConfiguration<TConfigType>> AccountGameConfiguration { get; set; }

		public DbSet<CharacterGameConfiguration<TConfigType>> CharacterGameConfiguration { get; set; }

		public GameConfigurationDatabaseContext(DbContextOptions<GameConfigurationDatabaseContext<TConfigType>> options)
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
			modelBuilder.Entity<AccountGameConfiguration<TConfigType>>(builder =>
			{
				builder.OwnsOne(o => o.Data, sa =>
				{
					sa.Property(p => p.Data).HasColumnName("data");
				});

				builder.HasKey(m => new {m.AccountId, m.Type});
			});

			//TODO: Support foreign keys for this some how
			modelBuilder.Entity<CharacterGameConfiguration<TConfigType>>(builder =>
			{
				builder.OwnsOne(o => o.Data, sa =>
				{
					sa.Property(p => p.Data).HasColumnName("data");
				});

				builder.HasKey(m => new { m.CharacterId, m.Type });
			});

			modelBuilder.Entity<GameConfigurationType<TConfigType>>()
				.SeedWithEnum<GameConfigurationType<TConfigType>, TConfigType>(val => new GameConfigurationType<TConfigType>(val, val.ToString(), String.Empty));
		}
	}
}
