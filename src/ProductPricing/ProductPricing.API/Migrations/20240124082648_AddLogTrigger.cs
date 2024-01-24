using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductPricing.API.Migrations
{
    /// <inheritdoc />
    public partial class AddLogTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var guid = Guid.NewGuid();

                var createTriggerFunction = @"
                CREATE OR REPLACE FUNCTION log_trigger()
                RETURNS TRIGGER AS $$
                BEGIN
                    INSERT INTO ""TriggerLogs""(""Id"", ""TableName"", ""Action"", ""ActionTime"" )
                    VALUES (gen_random_uuid(), TG_TABLE_NAME, 'INSERT', CURRENT_TIMESTAMP);
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;";

                migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS pgcrypto");

            migrationBuilder.Sql(createTriggerFunction);
            
            var createTriggerOnCurrentTarriffs = @"
                CREATE TRIGGER ""TriggerLogs""
                AFTER INSERT ON ""CurrentTariffs""
                FOR EACH ROW
                EXECUTE PROCEDURE log_trigger();";
            
            migrationBuilder.Sql(createTriggerOnCurrentTarriffs);
            
            
            var createTriggerOnTariffTable = @"
                CREATE TRIGGER ""TriggerLogs""
                AFTER INSERT ON ""Tariffs""
                FOR EACH ROW
                EXECUTE PROCEDURE log_trigger();";
            
            migrationBuilder.Sql(createTriggerOnTariffTable);
            
            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "LocationId", "PricePerHour", "TaxBasisPoints", "ValidFrom", "ValidTo" },
                values: new object[] { new Guid("99999ace-8456-47fb-8d74-0609c939b927"), "1234", 2, 1900, new DateTime(2023, 1, 23, 10, 32, 22, 743, DateTimeKind.Utc).AddTicks(3860), new DateTime(2025, 1, 22, 10, 32, 22, 743, DateTimeKind.Utc).AddTicks(3920) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
