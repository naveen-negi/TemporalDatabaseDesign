using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductPricing.API.Migrations
{
    /// <inheritdoc />
    public partial class RemovePriorityAndSetDefaultValueForTariffType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE ""CurrentTariffs"" DROP CONSTRAINT ""NO_OVERLAPPING_PRIORITIES"";");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "CurrentTariffs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "CurrentTariffs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
