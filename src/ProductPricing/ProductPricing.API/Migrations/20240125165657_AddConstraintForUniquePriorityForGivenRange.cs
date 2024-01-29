using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductPricing.API.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintForUniquePriorityForGivenRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS btree_gist;");
            
            migrationBuilder.Sql(
                @"ALTER TABLE ""CurrentTariffs"" ADD CONSTRAINT ""NO_OVERLAPPING_PRIORITIES""
                EXCLUDE USING GIST (
                    ""LocationId"" WITH =,
                    ""PriceSince"" WITH &&,
                (CASE WHEN ""Priority"" IS NOT NULL THEN ""Priority"" END) WITH <>
                );");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
