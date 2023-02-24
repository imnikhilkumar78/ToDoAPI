using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    public partial class newFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ListTitles",
                columns: table => new
                {
                    ListId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListTitles", x => x.ListId);
                    table.ForeignKey(
                        name: "FK_ListTitles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Listitems",
                columns: table => new
                {
                    ListItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ListId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listitems", x => x.ListItemId);
                    table.ForeignKey(
                        name: "FK_Listitems_ListTitles_ListId",
                        column: x => x.ListId,
                        principalTable: "ListTitles",
                        principalColumn: "ListId");
                    table.ForeignKey(
                        name: "FK_Listitems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listitems_ListId",
                table: "Listitems",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Listitems_UserId",
                table: "Listitems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListTitles_UserId",
                table: "ListTitles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listitems");

            migrationBuilder.DropTable(
                name: "ListTitles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
