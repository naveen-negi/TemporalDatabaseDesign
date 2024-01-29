using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductPricing.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTriggerToMatchRestOfTheRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createPackingTriggerFunction = @"
            CREATE OR REPLACE FUNCTION pack_price_since()
            RETURNS TRIGGER AS $$
            Declare rec RECORD;
            BEGIN
                -- Loop through existing records to find and merge overlapping ranges
                FOR rec IN
                    SELECT * FROM ""CurrentTariffs""
                    WHERE ""LocationId"" = NEW.""LocationId""
                    AND (""PriceSince"" && NEW.""PriceSince"" OR ""PriceSince"" -|- NEW.""PriceSince"")
                    AND ""TariffType"" = NEW.""TariffType""
                    AND ""PricePerHour"" = NEW.""PricePerHour""
                    AND ""Id"" != NEW.""Id""
                LOOP
                    -- Merge ranges and delete the old record
                    NEW.""PriceSince"" := daterange(
                        LEAST(lower(NEW.""PriceSince""), lower(rec.""PriceSince"")),
                        GREATEST(upper(NEW.""PriceSince""), upper(rec.""PriceSince""))
                    );
                    DELETE FROM ""CurrentTariffs"" WHERE ""Id"" = rec.""Id"";
                END LOOP;

                -- Insert or update the record with the merged range
                RETURN NEW;
            END;
            $$ LANGUAGE plpgsql;";

            migrationBuilder.Sql(createPackingTriggerFunction);
            
            migrationBuilder.Sql(@"
            DROP TRIGGER IF EXISTS pack_price_since_trigger ON ""CurrentTariffs"";
            CREATE TRIGGER pack_price_since_trigger
            BEFORE INSERT OR UPDATE ON ""CurrentTariffs""
            FOR EACH ROW EXECUTE FUNCTION pack_price_since();");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
