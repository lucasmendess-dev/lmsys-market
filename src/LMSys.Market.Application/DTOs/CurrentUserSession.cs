namespace LMSys.Market.Application.DTOs;

public sealed record CurrentUserSession(
    long UserId,
    string Name,
    string Username,
    long RoleId,
    string RoleName,
    long StoreId,
    string StoreName,
    IReadOnlyCollection<string> Permissions);