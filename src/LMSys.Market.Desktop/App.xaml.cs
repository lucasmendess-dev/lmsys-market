using LMSys.Market.Application.Interfaces;
using LMSys.Market.Application.Services;
using LMSys.Market.Desktop.Services;
using LMSys.Market.Desktop.ViewModels;
using LMSys.Market.Desktop.Views;
using LMSys.Market.Infrastructure.Data.Context;
using LMSys.Market.Infrastructure.Data.Seed;
using LMSys.Market.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace LMSys.Market.Desktop;

public partial class App : System.Windows.Application
{
    private readonly IHost _host;

    private static readonly string ErrorLogPath =
        Path.Combine(
            AppContext.BaseDirectory,
            "lmsys-market-error.log");

    public App()
    {
        ShutdownMode = ShutdownMode.OnExplicitShutdown;

        DispatcherUnhandledException +=
            OnDispatcherUnhandledException;

        AppDomain.CurrentDomain.UnhandledException +=
            OnUnhandledException;

        TaskScheduler.UnobservedTaskException +=
            OnUnobservedTaskException;

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

                        services.AddSingleton<
                            ICurrentUserService,
                            CurrentUserService>();

                        services.AddScoped<
                            IAuthenticationService,
                            AuthenticationService>();

                        services.AddSingleton<
                            IWindowNavigationService,
                            WindowNavigationService>();

                        services.AddTransient<LoginViewModel>();
                        services.AddTransient<MainViewModel>();

                        services.AddTransient<LoginWindow>();
                        services.AddTransient<MainWindow>();
                    })
                .Build();
    }

    protected override async void OnStartup(
        StartupEventArgs e)
    {
        base.OnStartup(e);

        ShutdownMode =
            ShutdownMode.OnExplicitShutdown;

        try
        {
            WriteLog(
                "Aplicação iniciada.");

            await _host.StartAsync();

            using var scope =
                _host.Services.CreateScope();

            var dbContext =
                scope.ServiceProvider
                    .GetRequiredService<
                        LMSysMarketDbContext>();

            await dbContext.Database
                .MigrateAsync();

            var seeder =
                scope.ServiceProvider
                    .GetRequiredService<
                        DatabaseSeeder>();

            await seeder.SeedAsync();

            var navigationService =
                _host.Services
                    .GetRequiredService<
                        IWindowNavigationService>();

            WriteLog(
                "Abrindo LoginWindow.");

            navigationService
                .ShowLoginWindow();
        }
        catch (Exception exception)
        {
            WriteException(
                "Erro durante OnStartup",
                exception);

            MessageBox.Show(
                exception.ToString(),
                "Erro ao iniciar LMSys Market",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            Shutdown();
        }
    }

    protected override async void OnExit(
        ExitEventArgs e)
    {
        WriteLog(
            "OnExit foi chamado.");

        try
        {
            await _host.StopAsync();
        }
        catch (Exception exception)
        {
            WriteException(
                "Erro ao encerrar Host",
                exception);
        }

        _host.Dispose();

        base.OnExit(e);
    }

    private void OnDispatcherUnhandledException(
        object sender,
        DispatcherUnhandledExceptionEventArgs e)
    {
        WriteException(
            "DispatcherUnhandledException",
            e.Exception);

        MessageBox.Show(
            e.Exception.ToString(),
            "Erro não tratado - LMSys Market",
            MessageBoxButton.OK,
            MessageBoxImage.Error);

        e.Handled = true;
    }

    private static void OnUnhandledException(
        object sender,
        UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception exception)
        {
            WriteException(
                "AppDomain.UnhandledException",
                exception);
        }
        else
        {
            WriteLog(
                $"Erro não tratado: {e.ExceptionObject}");
        }
    }

    private static void OnUnobservedTaskException(
        object? sender,
        UnobservedTaskExceptionEventArgs e)
    {
        WriteException(
            "TaskScheduler.UnobservedTaskException",
            e.Exception);

        e.SetObserved();
    }

    public static void WriteLog(
        string message)
    {
        try
        {
            File.AppendAllText(
                ErrorLogPath,
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] " +
                $"{message}{Environment.NewLine}");
        }
        catch
        {
            // Nunca lançar erro a partir do logger
            // de diagnóstico.
        }
    }

    public static void WriteException(
        string context,
        Exception exception)
    {
        WriteLog(
            $"{context}{Environment.NewLine}" +
            $"{exception}{Environment.NewLine}");
    }
}