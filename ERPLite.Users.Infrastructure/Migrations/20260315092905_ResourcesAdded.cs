using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPLite.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResourcesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources_Id", x => x.Id);
                    table.CheckConstraint("CK_Resources_Lang", "LEN(Lang) >= 2");
                    table.CheckConstraint("CK_Resources_Name", "LEN(Name) >= 2");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Resources_Lang_Name",
                table: "Resources",
                columns: new[] { "Lang", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
