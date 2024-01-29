using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NpgsqlTypes;

namespace ProductPricing.API.Entities;

public class CurrentTariff
{
    public CurrentTariff(Guid id, string locationId, NpgsqlRange<DateTime> priceSince, int pricePerHour, TariffType tariffType)
    {
        Id = id;
        LocationId = locationId;
        PriceSince = priceSince;
        PricePerHour = pricePerHour;
        TariffType = tariffType;
    }

    public Guid Id { get; private set; }
   
    public string LocationId { get; private set; }
    
    public NpgsqlRange<DateTime> PriceSince { get; private set; }
    
    public int PricePerHour { get; private set; }
    
    [Column(TypeName = "varchar(255)")]
    [EnumDataType(typeof(TariffType))]
    [DefaultValue(TariffType.Standard)]
    public TariffType TariffType { get; private set; } 
}

public enum TariffType
{
    Standard,
    Peak,
    OffPeak,
    Weekend,
    PublicHoliday,
    Special,
    Other
}