using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiForTest.Migrations
{
    /// <inheritdoc />
    public partial class newTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReSultDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberRDoc = table.Column<int>(type: "int", nullable: false),
                    DateRDoc = table.Column<DateOnly>(type: "date", nullable: false),
                    NameResource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountRResource = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReSultDb", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReSultDb");
        }
    }
}
