using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericCalendar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFinetuningSubtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Equipment",
                newName: "EquipmentType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EquipmentType",
                table: "Equipment",
                newName: "Type");
        }
    }
}
