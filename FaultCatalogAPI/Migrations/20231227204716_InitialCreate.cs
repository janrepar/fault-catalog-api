﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaultCatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuccessCriteria",
                columns: table => new
                {
                    RefId = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    Level = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuccessCriteria", x => x.RefId);
                });

            migrationBuilder.CreateTable(
                name: "FaultSuccessCriterion",
                columns: table => new
                {
                    FaultsId = table.Column<long>(type: "INTEGER", nullable: false),
                    SuccessCriteriaRefId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultSuccessCriterion", x => new { x.FaultsId, x.SuccessCriteriaRefId });
                    table.ForeignKey(
                        name: "FK_FaultSuccessCriterion_Faults_FaultsId",
                        column: x => x.FaultsId,
                        principalTable: "Faults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaultSuccessCriterion_SuccessCriteria_SuccessCriteriaRefId",
                        column: x => x.SuccessCriteriaRefId,
                        principalTable: "SuccessCriteria",
                        principalColumn: "RefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaultSuccessCriterion_SuccessCriteriaRefId",
                table: "FaultSuccessCriterion",
                column: "SuccessCriteriaRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaultSuccessCriterion");

            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "SuccessCriteria");
        }
    }
}
