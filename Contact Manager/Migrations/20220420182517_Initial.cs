using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact_Manager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
                    Organization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Managers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "1", "Friend" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "2", "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "3", "Family" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CategoryId", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[] { 1, "1", "john.doe@gmail.com", "John", "Doe", "Google", "8591112234" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "CategoryId", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[] { 2, "2", "joe.burrow@gmail.com", "Joe", "Burrow", "Cincinnati Bengals", "5131234567" });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_CategoryId",
                table: "Managers",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
