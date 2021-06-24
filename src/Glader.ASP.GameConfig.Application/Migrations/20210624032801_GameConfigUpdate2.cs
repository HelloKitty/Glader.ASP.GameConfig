using Microsoft.EntityFrameworkCore.Migrations;

namespace Glader.ASP.GameConfig.Application.Migrations
{
    public partial class GameConfigUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "gameconfig_type",
                columns: new[] { "Type", "Description", "VisualName" },
                values: new object[] { 1, "", "Keybind" });

            migrationBuilder.InsertData(
                table: "gameconfig_type",
                columns: new[] { "Type", "Description", "VisualName" },
                values: new object[] { 2, "", "Actionbar" });

            migrationBuilder.InsertData(
                table: "gameconfig_type",
                columns: new[] { "Type", "Description", "VisualName" },
                values: new object[] { 3, "", "Video" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "gameconfig_type",
                keyColumn: "Type",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "gameconfig_type",
                keyColumn: "Type",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "gameconfig_type",
                keyColumn: "Type",
                keyValue: 3);
        }
    }
}
