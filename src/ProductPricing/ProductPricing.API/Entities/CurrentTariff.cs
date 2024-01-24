using NpgsqlTypes;

namespace ProductPricing.API.Entities;

public class CurrentTariff
{
    public CurrentTariff(Guid id, string locationId, int priority, NpgsqlRange<DateTime> priceSince, int pricePerHour)
    {
        Id = id;
        LocationId = locationId;
        Priority = priority;
        PriceSince = priceSince;
        PricePerHour = pricePerHour;
    }

    public Guid Id { get; private set; }
   
    public string LocationId { get; private set; }
    
    public int Priority { get; private set; }
    
    public NpgsqlRange<DateTime> PriceSince { get; private set; }
    
    public int PricePerHour { get; private set; }
    
}