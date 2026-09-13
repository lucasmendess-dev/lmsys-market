using LMSys.Market.Application.DTOs;

namespace LMSys.Market.Application.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResult> AuthenticateAsync(
        string identifier,
        string password,
        CancellationToken cancellationToken = default);
}