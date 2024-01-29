using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductPricing.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTariffTypeToCurrentTariffs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TariffType",
                table: "CurrentTariffs",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TariffType",
                table: "CurrentTariffs");
        }
    }
}
