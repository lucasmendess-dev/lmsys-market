using LMSys.Market.Domain.Entities;

namespace LMSys.Market.Application.DTOs;

public sealed record UserAuthenticationData(
    User User,
    string RoleName,
    long StoreId,
    string StoreName,
    IReadOnlyCollection<string> Permissions);