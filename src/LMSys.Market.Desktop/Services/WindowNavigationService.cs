using LMSys.Market.Application.Interfaces;
using LMSys.Market.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LMSys.Market.Desktop.Services;

public sealed class WindowNavigationService
    : IWindowNavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICurrentUserService _currentUserService;

    private Window? _currentWindow;
    private bool _isNavigating;

    public WindowNavigationService(
        IServiceProvider serviceProvider,
        ICurrentUserService currentUserService)
    {
        _serviceProvider = serviceProvider;
        _currentUserService = currentUserService;
    }

    public void ShowLoginWindow()
    {
        var loginWindow =
            _serviceProvider
                .GetRequiredService<LoginWindow>();

        ShowWindow(loginWindow);
    }

    public void ShowMainWindow()
    {
        var mainWindow =
            _serviceProvider
                .GetRequiredService<MainWindow>();

        ShowWindow(mainWindow);
    }

    public void Logout()
    {
        _currentUserService.Clear();

        ShowLoginWindow();
    }

    private void ShowWindow(Window newWindow)
    {
        var previousWindow = _currentWindow;

        try
        {
            _isNavigating = true;

            newWindow.Closed += OnWindowClosed;

            _currentWindow = newWindow;

            System.Windows.Application.Current.MainWindow =
                newWindow;

            newWindow.Show();

            if (previousWindow is not null)
            {
                previousWindow.Closed -=
                    OnWindowClosed;

                previousWindow.Close();
            }
        }
        finally
        {
            _isNavigating = false;
        }
    }

    private void OnWindowClosed(
        object? sender,
        EventArgs e)
    {
        if (_isNavigating)
            return;

        if (sender is Window window)
        {
            window.Closed -= OnWindowClosed;
        }

        _currentWindow = null;

        System.Windows.Application.Current.Shutdown();
    }
}