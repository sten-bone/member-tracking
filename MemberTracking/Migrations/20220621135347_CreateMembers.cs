using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemberTracking.Migrations
{
    public partial class CreateMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 1, "Kara", "Sullivan", "Percival" },
                    { 2, "Stephen", "Hollinden", "Maxwell" },
                    { 3, "Caldwell", "Crawford", "Cooper" },
                    { 4, "Mary", "Richter", "Sue" },
                    { 5, "Elisabeth", "Scott", "Walder" },
                    { 6, "Michael", "Charles", "Utrauer" },
                    { 7, "Charlotte", "Wilson", "Alice" },
                    { 8, "James", "Anderson", "Edward" },
                    { 9, "Ahmed", "Kumar", "Yan" },
                    { 10, "Nushi", "Huang", "Li" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
