using LMSys.Market.Application.DTOs;
using LMSys.Market.Application.Interfaces;

namespace LMSys.Market.Application.Services;

public sealed class CurrentUserService : ICurrentUserService
{
    public bool IsAuthenticated =>
        Session is not null;

    public CurrentUserSession? Session { get; private set; }

    public void SetSession(CurrentUserSession session)
    {
        ArgumentNullException.ThrowIfNull(session);

        Session = session;
    }

    public void Clear()
    {
        Session = null;
    }
}