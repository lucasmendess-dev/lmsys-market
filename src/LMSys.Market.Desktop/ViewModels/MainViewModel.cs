using LMSys.Market.Application.Interfaces;
using LMSys.Market.Desktop.Commands;
using LMSys.Market.Desktop.Services;

namespace LMSys.Market.Desktop.ViewModels;

public sealed class MainViewModel : ViewModelBase
{
    private readonly IWindowNavigationService
        _navigationService;

    public MainViewModel(
        ICurrentUserService currentUserService,
        IWindowNavigationService navigationService)
    {
        _navigationService =
            navigationService;

        var session =
            currentUserService.Session
            ?? throw new InvalidOperationException(
                "Não existe usuário autenticado.");

        UserName = session.Name;
        RoleName = session.RoleName;
        StoreName = session.StoreName;

        LogoutCommand =
            new RelayCommand(Logout);
    }

    public string UserName { get; }

    public string RoleName { get; }

    public string StoreName { get; }

    public RelayCommand LogoutCommand { get; }

    private void Logout()
    {
        _navigationService.Logout();
    }
}