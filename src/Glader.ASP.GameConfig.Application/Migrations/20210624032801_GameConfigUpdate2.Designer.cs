﻿// <auto-generated />
using System;
using Glader.ASP.GameConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Glader.ASP.GameConfig.Application.Migrations
{
    [DbContext(typeof(GameConfigurationDatabaseContext<TestConfigType>))]
    [Migration("20210624032801_GameConfigUpdate2")]
    partial class GameConfigUpdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Glader.ASP.GameConfig.AccountGameConfiguration<Glader.ASP.GameConfig.TestConfigType>", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("int");

                    b.HasKey("AccountId", "Type");

                    b.HasIndex("Type");

                    b.ToTable("gameconfig_account");
                });

            modelBuilder.Entity("Glader.ASP.GameConfig.CharacterGameConfiguration<Glader.ASP.GameConfig.TestConfigType>", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "Type");

                    b.HasIndex("Type");

                    b.ToTable("gameconfig_character");
                });

            modelBuilder.Entity("Glader.ASP.GameConfig.GameConfigurationType<Glader.ASP.GameConfig.TestConfigType>", b =>
                {
                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("VisualName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Type");

                    b.ToTable("gameconfig_type");

                    b.HasData(
                        new
                        {
                            Type = 1,
                            Description = "",
                            VisualName = "Keybind"
                        },
                        new
                        {
                            Type = 2,
                            Description = "",
                            VisualName = "Actionbar"
                        },
                        new
                        {
                            Type = 3,
                            Description = "",
                            VisualName = "Video"
                        });
                });

            modelBuilder.Entity("Glader.ASP.GameConfig.AccountGameConfiguration<Glader.ASP.GameConfig.TestConfigType>", b =>
                {
                    b.HasOne("Glader.ASP.GameConfig.GameConfigurationType<Glader.ASP.GameConfig.TestConfigType>", "Config")
                        .WithMany()
                        .HasForeignKey("Type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Glader.ASP.GameConfig.GameConfigData", "Data", b1 =>
                        {
                            b1.Property<int>("AccountGameConfiguration<TestConfigType>AccountId")
                                .HasColumnType("int");

                            b1.Property<int>("AccountGameConfiguration<TestConfigType>Type")
                                .HasColumnType("int");

                            b1.Property<byte[]>("Data")
                                .IsRequired()
                                .HasColumnName("data")
                                .HasColumnType("longblob");

                            b1.HasKey("AccountGameConfiguration<TestConfigType>AccountId", "AccountGameConfiguration<TestConfigType>Type");

                            b1.ToTable("gameconfig_account");

                            b1.WithOwner()
                                .HasForeignKey("AccountGameConfiguration<TestConfigType>AccountId", "AccountGameConfiguration<TestConfigType>Type");
                        });
                });

            modelBuilder.Entity("Glader.ASP.GameConfig.CharacterGameConfiguration<Glader.ASP.GameConfig.TestConfigType>", b =>
                {
                    b.HasOne("Glader.ASP.GameConfig.GameConfigurationType<Glader.ASP.GameConfig.TestConfigType>", "Config")
                        .WithMany()
                        .HasForeignKey("Type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Glader.ASP.GameConfig.GameConfigData", "Data", b1 =>
                        {
                            b1.Property<int>("CharacterGameConfiguration<TestConfigType>CharacterId")
                                .HasColumnType("int");

                            b1.Property<int>("CharacterGameConfiguration<TestConfigType>Type")
                                .HasColumnType("int");

                            b1.Property<byte[]>("Data")
                                .IsRequired()
                                .HasColumnName("data")
                                .HasColumnType("longblob");

                            b1.HasKey("CharacterGameConfiguration<TestConfigType>CharacterId", "CharacterGameConfiguration<TestConfigType>Type");

                            b1.ToTable("gameconfig_character");

                            b1.WithOwner()
                                .HasForeignKey("CharacterGameConfiguration<TestConfigType>CharacterId", "CharacterGameConfiguration<TestConfigType>Type");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
