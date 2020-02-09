using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _3LTB.Migrations
{
    public partial class AddPostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    DepartureCity = table.Column<string>(nullable: true),
                    Trade = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Flight = table.Column<int>(nullable: false),
                    FlightDate = table.Column<DateTime>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Report = table.Column<string>(nullable: true),
                    Lang = table.Column<bool>(nullable: false),
                    ArrivalCity = table.Column<string>(nullable: true),
                    RedFlag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
