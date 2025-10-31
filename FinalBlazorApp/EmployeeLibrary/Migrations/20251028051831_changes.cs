using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeLibrary.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    EmpName = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Designation = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
