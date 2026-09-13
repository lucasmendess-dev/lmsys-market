using LMSys.Market.Domain.Common;

namespace LMSys.Market.Domain.Entities;

public sealed class Role : Entity
{
    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    private Role()
    {
    }

    public Role(
        string name,
        string? description,
        DateTimeOffset createdAt)
        : base(createdAt)
    {
        Name = Guard.Required(name, "Nome do perfil", 80);
        Description = Guard.Optional(
            description,
            "Descrição",
            250);

        IsActive = true;
    }

    public void Update(
        string name,
        string? description,
        DateTimeOffset updatedAt)
    {
        Name = Guard.Required(name, "Nome do perfil", 80);
        Description = Guard.Optional(
            description,
            "Descrição",
            250);

        MarkAsUpdated(updatedAt);
    }

    public void Activate(DateTimeOffset updatedAt)
    {
        IsActive = true;
        MarkAsUpdated(updatedAt);
    }

    public void Deactivate(DateTimeOffset updatedAt)
    {
        IsActive = false;
        MarkAsUpdated(updatedAt);
    }
}