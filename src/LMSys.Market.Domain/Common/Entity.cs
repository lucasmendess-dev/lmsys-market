namespace LMSys.Market.Domain.Common;

public abstract class Entity
{
    public long Id { get; protected set; }

    public DateTimeOffset CreatedAt { get; protected set; }

    public DateTimeOffset UpdatedAt { get; protected set; }

    protected Entity()
    {
    }

    protected Entity(DateTimeOffset createdAt)
    {
        CreatedAt = createdAt;
        UpdatedAt = createdAt;
    }

    protected void MarkAsUpdated(DateTimeOffset updatedAt)
    {
        UpdatedAt = updatedAt;
    }
}