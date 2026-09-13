using LMSys.Market.Application.DTOs;

namespace LMSys.Market.Application.Interfaces;

public interface ICurrentUserService
{
    bool IsAuthenticated { get; }

    CurrentUserSession? Session { get; }

    void SetSession(CurrentUserSession session);

    void Clear();
}