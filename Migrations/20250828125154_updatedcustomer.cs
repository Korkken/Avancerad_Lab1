using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avancerad_Lab1.Migrations
{
    /// <inheritdoc />
    public partial class updatedcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_CustomerId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FK_CustomerId",
                table: "Reservations");
        }
    }
}
