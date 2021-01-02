﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Glader.ASP.GameConfig.Application.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "config_keybinding",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_keybinding", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "config_keybinding");
        }
    }
}
