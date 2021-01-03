using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyToDoList.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "Description", "DueDate", "IsDone", "Title" },
                values: new object[] { 1, null, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Wash the Car" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "Description", "DueDate", "IsDone", "Title" },
                values: new object[] { 2, null, new DateTime(2019, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Do Home Work" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
