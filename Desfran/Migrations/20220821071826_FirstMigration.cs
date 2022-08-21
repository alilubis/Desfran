using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desfran.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Email);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Email", "Id", "Password", "Username" },
                values: new object[] { "Admin@gmail.com", 1, "1621568719813777238110130818113881921121202386373191", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
