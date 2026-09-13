using LMSys.Market.Application.DTOs;

namespace LMSys.Market.Application.Interfaces;

public interface IUserRepository
{
    Task<UserAuthenticationData?> GetForAuthenticationAsync(
        string identifier,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}