using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OwnerManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Owner");

            migrationBuilder.CreateTable(
                name: "Owners",
                schema: "Owner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualUnits",
                schema: "Owner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualUnits_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Owner",
                        principalTable: "Owners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualUnits_OwnerId",
                schema: "Owner",
                table: "IndividualUnits",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualUnits",
                schema: "Owner");

            migrationBuilder.DropTable(
                name: "Owners",
                schema: "Owner");
        }
    }
}
