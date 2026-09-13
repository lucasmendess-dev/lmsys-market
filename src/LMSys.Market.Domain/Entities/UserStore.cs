using LMSys.Market.Domain.Common;

namespace LMSys.Market.Domain.Entities;

public sealed class UserStore
{
    public long UserId { get; private set; }

    public long StoreId { get; private set; }

    private UserStore()
    {
    }

    public UserStore(
        long userId,
        long storeId)
    {
        UserId = Guard.PositiveId(userId, "Usuário");
        StoreId = Guard.PositiveId(storeId, "Loja");
    }
}