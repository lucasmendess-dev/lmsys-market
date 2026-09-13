using LMSys.Market.Application.Interfaces;
using LMSys.Market.Infrastructure.Authentication;
using LMSys.Market.Infrastructure.Data.Context;
using LMSys.Market.Infrastructure.Data.Seed;
using LMSys.Market.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LMSys.Market.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException(
                "A connection string do banco é obrigatória.",
                nameof(connectionString));
        }

        services.AddDbContext<LMSysMarketDbContext>(
            options =>
                options.UseNpgsql(
                    connectionString));

        services.AddScoped<
            IPasswordHasher,
            PasswordHasherService>();

        services.AddScoped<
            IUserRepository,
            UserRepository>();

        services.AddScoped<DatabaseSeeder>();

        return services;
    }
}