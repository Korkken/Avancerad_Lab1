using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avancerad_Lab1.Migrations
{
    /// <inheritdoc />
    public partial class addeddateonly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Seatings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Seatings");
        }
    }
}
