using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LMSys.Market.Infrastructure.Data.Context;

public sealed class LMSysMarketDbContextFactory
    : IDesignTimeDbContextFactory<LMSysMarketDbContext>
{
    public LMSysMarketDbContext CreateDbContext(string[] args)
    {
        var connectionString =
            Environment.GetEnvironmentVariable(
                "LMSYS_MARKET_DB_CONNECTION");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString =
                "Host=localhost;" +
                "Port=5432;" +
                "Database=lmsys_market_dev;" +
                "Username=postgres";
        }

        var optionsBuilder =
            new DbContextOptionsBuilder<LMSysMarketDbContext>();

        optionsBuilder.UseNpgsql(connectionString);

        return new LMSysMarketDbContext(
            optionsBuilder.Options);
    }
}