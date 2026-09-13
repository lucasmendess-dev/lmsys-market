using LMSys.Market.Application.Interfaces;
using LMSys.Market.Desktop.Commands;
using LMSys.Market.Desktop.Services;

namespace LMSys.Market.Desktop.ViewModels;

public sealed class LoginViewModel : ViewModelBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IWindowNavigationService _navigationService;

    private string _identifier = string.Empty;
    private string _password = string.Empty;
    private string _errorMessage = string.Empty;
    private bool _isBusy;

    public LoginViewModel(
        IAuthenticationService authenticationService,
        IWindowNavigationService navigationService)
    {
        _authenticationService = authenticationService;
        _navigationService = navigationService;

        LoginCommand = new AsyncRelayCommand(
            LoginAsync,
            CanLogin);
    }

    public string Identifier
    {
        get => _identifier;

        set
        {
            if (SetProperty(
                    ref _identifier,
                    value))
            {
                LoginCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public string Password
    {
        get => _password;

        set
        {
            if (SetProperty(
                    ref _password,
                    value))
            {
                LoginCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;

        private set =>
            SetProperty(
                ref _errorMessage,
                value);
    }

    public bool IsBusy
    {
        get => _isBusy;

        private set
        {
            if (SetProperty(
                    ref _isBusy,
                    value))
            {
                OnPropertyChanged(
                    nameof(LoginButtonText));

                LoginCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public string LoginButtonText =>
        IsBusy
            ? "ENTRANDO..."
            : "ENTRAR";

    public AsyncRelayCommand LoginCommand { get; }

    private bool CanLogin()
    {
        return
            !IsBusy &&
            !string.IsNullOrWhiteSpace(Identifier) &&
            !string.IsNullOrWhiteSpace(Password);
    }

    private async Task LoginAsync()
    {
        try
        {
            IsBusy = true;

            ErrorMessage = string.Empty;

            var result =
                await _authenticationService
                    .AuthenticateAsync(
                        Identifier,
                        Password);

            if (!result.Succeeded)
            {
                ErrorMessage =
                    result.ErrorMessage ??
                    "Não foi possível entrar.";

                return;
            }

            Password = string.Empty;

            _navigationService.ShowMainWindow();
        }
        catch (Exception exception)
        {
            ErrorMessage =
                $"Erro ao abrir o sistema: {exception.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
}