using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agid.production.planner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tahun = table.Column<int>(type: "INTEGER", nullable: false),
                    MingguKe = table.Column<int>(type: "INTEGER", nullable: false),
                    Hari = table.Column<int>(type: "INTEGER", nullable: false),
                    PlannedProduction = table.Column<int>(type: "INTEGER", nullable: false),
                    ActualProduction = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionSchedule", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionSchedule");
        }
    }
}
