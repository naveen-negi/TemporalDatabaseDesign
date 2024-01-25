using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace ProductPricing.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangePriceSinceColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceSince",
                table: "CurrentTariffs");
            
            migrationBuilder.AddColumn<NpgsqlRange<DateTime>>(
                name: "PriceSince",
                table: "CurrentTariffs",
                type: "daterange",
                nullable: false);
                
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
