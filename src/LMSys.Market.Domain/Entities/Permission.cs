using LMSys.Market.Domain.Common;

namespace LMSys.Market.Domain.Entities;

public sealed class Permission : Entity
{
    public string Code { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    private Permission()
    {
    }

    public Permission(
        string code,
        string name,
        string? description,
        DateTimeOffset createdAt)
        : base(createdAt)
    {
        Code = Guard.Required(code, "Código da permissão", 120);
        Name = Guard.Required(name, "Nome da permissão", 120);
        Description = Guard.Optional(
            description,
            "Descrição",
            250);
    }

    public void Update(
        string name,
        string? description,
        DateTimeOffset updatedAt)
    {
        Name = Guard.Required(name, "Nome da permissão", 120);
        Description = Guard.Optional(
            description,
            "Descrição",
            250);

        MarkAsUpdated(updatedAt);
    }
}