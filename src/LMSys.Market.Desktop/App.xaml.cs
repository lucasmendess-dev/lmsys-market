using LMSys.Market.Infrastructure.Data.Context;
using LMSys.Market.Infrastructure.Data.Seed;
using LMSys.Market.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace LMSys.Market.Desktop;

public partial class App : System.Windows.Application
{
    private readonly IHost _host;

    public App()
    {
        _host =
            Host.CreateDefaultBuilder()
                .ConfigureServices(
                    services =>
                    {
                        var connectionString =
                            Environment.GetEnvironmentVariable(
                                "LMSYS_MARKET_DB_CONNECTION");

                        if (string.IsNullOrWhiteSpace(
                                connectionString))
                        {
                            throw new InvalidOperationException(
                                "A variável LMSYS_MARKET_DB_CONNECTION " +
                                "não foi configurada.");
                        }

                        services.AddInfrastructure(
                            connectionString);

                        services.AddSingleton<MainWindow>();
                    })
                .Build();
    }

    protected override async void OnStartup(
        StartupEventArgs e)
    {
        base.OnStartup(e);

        try
        {
            await _host.StartAsync();

            using var scope =
                _host.Services.CreateScope();

            var dbContext =
                scope.ServiceProvider
                    .GetRequiredService<
                        LMSysMarketDbContext>();

            await dbContext.Database.MigrateAsync();

            var seeder =
                scope.ServiceProvider
                    .GetRequiredService<
                        DatabaseSeeder>();

            await seeder.SeedAsync();

            var mainWindow =
                _host.Services
                    .GetRequiredService<MainWindow>();

            mainWindow.Show();
        }
        catch (Exception exception)
        {
            MessageBox.Show(
                exception.Message,
                "LMSys Market",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            Shutdown();
        }
    }

    protected override async void OnExit(
        ExitEventArgs e)
    {
        await _host.StopAsync();

        _host.Dispose();

        base.OnExit(e);
    }
}