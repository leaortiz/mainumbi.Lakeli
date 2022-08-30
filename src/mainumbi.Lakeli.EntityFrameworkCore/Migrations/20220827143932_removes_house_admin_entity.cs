using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mainumbi.Lakeli.Migrations
{
    public partial class removes_house_admin_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App.Customer");

            migrationBuilder.RenameColumn(
                name: "HouseAdminId",
                table: "App.Job",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "App.Job",
                newName: "HouseAdminId");

            migrationBuilder.CreateTable(
                name: "App.Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.Customer", x => x.Id);
                });
        }
    }
}
