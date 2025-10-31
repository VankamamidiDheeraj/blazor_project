using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class changep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    TrainerName = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Type = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.TrainerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainer");
        }
    }
}
