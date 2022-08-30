using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mainumbi.Lakeli.Migrations
{
    public partial class adds_base_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "App.Laborer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.Laborer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App.Job",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LaborerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HouseAdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.Job_App.Laborer_LaborerId",
                        column: x => x.LaborerId,
                        principalTable: "App.Laborer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "App.Rating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Cleaning = table.Column<int>(type: "int", nullable: false),
                    Puntuality = table.Column<int>(type: "int", nullable: false),
                    LaborerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseAdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.Rating_App.Job_JobId",
                        column: x => x.JobId,
                        principalTable: "App.Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App.Rating_App.Laborer_LaborerId",
                        column: x => x.LaborerId,
                        principalTable: "App.Laborer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App.Job_LaborerId",
                table: "App.Job",
                column: "LaborerId");

            migrationBuilder.CreateIndex(
                name: "IX_App.Rating_JobId",
                table: "App.Rating",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.Rating_LaborerId",
                table: "App.Rating",
                column: "LaborerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App.Customer");

            migrationBuilder.DropTable(
                name: "App.Rating");

            migrationBuilder.DropTable(
                name: "App.Job");

            migrationBuilder.DropTable(
                name: "App.Laborer");
        }
    }
}
