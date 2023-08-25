using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlperenCrud.Migrations
{
    /// <inheritdoc />
    public partial class Persons1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    personId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personAge = table.Column<int>(type: "int", nullable: false),
                    personGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personIdentityId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.personId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
