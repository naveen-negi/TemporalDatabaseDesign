using Microsoft.EntityFrameworkCore;

namespace ProductPricing.API.Entities;

public class TariffDBContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public TariffDBContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("TariffDB"));
    }

    public DbSet<Tariff> Tariffs { get; set; } = null!;
    public DbSet<CurrentTariff> CurrentTariffs { get; set; } = null!;
    public DbSet<TriggerLog> TriggerLogs { get; set; } = null!;
}