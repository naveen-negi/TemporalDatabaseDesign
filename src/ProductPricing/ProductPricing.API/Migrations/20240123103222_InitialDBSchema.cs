using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductPricing.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PricePerHour = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<string>(type: "text", nullable: false),
                    TaxBasisPoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "LocationId", "PricePerHour", "TaxBasisPoints", "ValidFrom", "ValidTo" },
                values: new object[] { new Guid("81789ace-8456-47fb-8d74-0609c939b927"), "1234", 2, 1900, new DateTime(2023, 1, 23, 10, 32, 22, 743, DateTimeKind.Utc).AddTicks(3860), new DateTime(2025, 1, 22, 10, 32, 22, 743, DateTimeKind.Utc).AddTicks(3920) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tariffs");
        }
    }
}
