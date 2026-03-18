using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPLite.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UsersPasswordLength128 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Users_Password",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Users_Password",
                table: "Users",
                sql: "LEN(Password) = 128");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Users_Password",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Users_Password",
                table: "Users",
                sql: "LEN(Password) = 64");
        }
    }
}
