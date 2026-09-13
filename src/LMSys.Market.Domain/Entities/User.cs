using LMSys.Market.Domain.Common;
using LMSys.Market.Domain.Exceptions;

namespace LMSys.Market.Domain.Entities;

public sealed class User : Entity
{
    public string Name { get; private set; } = string.Empty;

    public string Username { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string PasswordHash { get; private set; } = string.Empty;

    public long RoleId { get; private set; }

    public bool IsActive { get; private set; }

    public DateTimeOffset? LastLoginAt { get; private set; }

    private User()
    {
    }

    public User(
        string name,
        string username,
        string email,
        string passwordHash,
        long roleId,
        DateTimeOffset createdAt)
        : base(createdAt)
    {
        Name = Guard.Required(name, "Nome", 150);
        Username = Guard.Required(username, "Usuário", 80);
        Email = Guard.Required(email, "E-mail", 150);
        PasswordHash = Guard.Required(
            passwordHash,
            "Hash da senha",
            255);

        RoleId = Guard.PositiveId(roleId, "Perfil");

        IsActive = true;
    }

    public void UpdateProfile(
        string name,
        string username,
        string email,
        DateTimeOffset updatedAt)
    {
        Name = Guard.Required(name, "Nome", 150);
        Username = Guard.Required(username, "Usuário", 80);
        Email = Guard.Required(email, "E-mail", 150);

        MarkAsUpdated(updatedAt);
    }

    public void ChangeRole(
        long roleId,
        DateTimeOffset updatedAt)
    {
        RoleId = Guard.PositiveId(roleId, "Perfil");
        MarkAsUpdated(updatedAt);
    }

    public void ChangePasswordHash(
        string passwordHash,
        DateTimeOffset updatedAt)
    {
        PasswordHash = Guard.Required(
            passwordHash,
            "Hash da senha",
            255);

        MarkAsUpdated(updatedAt);
    }

    public void RegisterLogin(DateTimeOffset loginAt)
    {
        if (!IsActive)
            throw new DomainException(
                "Usuário inativo não pode realizar login.");

        LastLoginAt = loginAt;
        MarkAsUpdated(loginAt);
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