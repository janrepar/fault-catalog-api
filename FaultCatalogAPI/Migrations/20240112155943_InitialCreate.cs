using Microsoft.EntityFrameworkCore.Migrations;

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
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SuccessCriterionRefIds = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "FaultsSuccessCriteria",
                columns: table => new
                {
                    FaultId = table.Column<long>(type: "INTEGER", nullable: false),
                    SuccessCriterionRefId = table.Column<string>(type: "TEXT", nullable: false),
                    FaultId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    SuccessCriterionRefId1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultsSuccessCriteria", x => new { x.FaultId, x.SuccessCriterionRefId });
                    table.ForeignKey(
                        name: "FK_FaultsSuccessCriteria_Faults_FaultId",
                        column: x => x.FaultId,
                        principalTable: "Faults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaultsSuccessCriteria_Faults_FaultId1",
                        column: x => x.FaultId1,
                        principalTable: "Faults",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaultsSuccessCriteria_SuccessCriteria_SuccessCriterionRefId",
                        column: x => x.SuccessCriterionRefId,
                        principalTable: "SuccessCriteria",
                        principalColumn: "RefId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaultsSuccessCriteria_SuccessCriteria_SuccessCriterionRefId1",
                        column: x => x.SuccessCriterionRefId1,
                        principalTable: "SuccessCriteria",
                        principalColumn: "RefId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaultsSuccessCriteria_FaultId1",
                table: "FaultsSuccessCriteria",
                column: "FaultId1");

            migrationBuilder.CreateIndex(
                name: "IX_FaultsSuccessCriteria_SuccessCriterionRefId",
                table: "FaultsSuccessCriteria",
                column: "SuccessCriterionRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultsSuccessCriteria_SuccessCriterionRefId1",
                table: "FaultsSuccessCriteria",
                column: "SuccessCriterionRefId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaultsSuccessCriteria");

            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "SuccessCriteria");
        }
    }
}
