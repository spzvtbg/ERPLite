using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPLite.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roels",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a01eb327-d8de-43fd-b21b-d44688e827de"), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Username" },
                values: new object[] { new Guid("8545b412-69ab-4a15-97d1-193b61d68507"), "noreply@admin.info", "Super User", "FB539A1B5A7880B8AC7D0D37F57F51C3065344A4402B553586CBA7B29E8168EB9BF94A24E6AB9F76364FDE904E4D03561A715F4BFF14A37AC5D1F9F7C1D7C3D4", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roels",
                keyColumn: "Id",
                keyValue: new Guid("a01eb327-d8de-43fd-b21b-d44688e827de"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8545b412-69ab-4a15-97d1-193b61d68507"));
        }
    }
}
