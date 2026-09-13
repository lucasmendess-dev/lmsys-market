using LMSys.Market.Application.DTOs;
using LMSys.Market.Application.Interfaces;

namespace LMSys.Market.Application.Services;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ICurrentUserService _currentUserService;

    public AuthenticationService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _currentUserService = currentUserService;
    }

    public async Task<AuthenticationResult> AuthenticateAsync(
        string identifier,
        string password,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(identifier) ||
            string.IsNullOrWhiteSpace(password))
        {
            return AuthenticationResult.Failure(
                "Informe o usuário e a senha.");
        }

        identifier = identifier.Trim();

        var authenticationData =
            await _userRepository.GetForAuthenticationAsync(
                identifier,
                cancellationToken);

        if (authenticationData is null)
        {
            return AuthenticationResult.Failure(
                "Usuário ou senha inválidos.");
        }

        var user = authenticationData.User;

        if (!user.IsActive)
        {
            return AuthenticationResult.Failure(
                "Este usuário está inativo.");
        }

        var passwordIsValid =
            _passwordHasher.Verify(
                user.PasswordHash,
                password);

        if (!passwordIsValid)
        {
            return AuthenticationResult.Failure(
                "Usuário ou senha inválidos.");
        }

        if (authenticationData.StoreId <= 0)
        {
            return AuthenticationResult.Failure(
                "O usuário não possui uma loja ativa vinculada.");
        }

        var now = DateTimeOffset.UtcNow;

        user.RegisterLogin(now);

        await _userRepository.SaveChangesAsync(
            cancellationToken);

        var session =
            new CurrentUserSession(
                UserId: user.Id,
                Name: user.Name,
                Username: user.Username,
                RoleId: user.RoleId,
                RoleName: authenticationData.RoleName,
                StoreId: authenticationData.StoreId,
                StoreName: authenticationData.StoreName,
                Permissions:
                    authenticationData.Permissions);

        _currentUserService.SetSession(session);

        return AuthenticationResult.Success();
    }
}