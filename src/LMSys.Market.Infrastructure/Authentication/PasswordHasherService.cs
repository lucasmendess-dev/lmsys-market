using LMSys.Market.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LMSys.Market.Infrastructure.Authentication;

public sealed class PasswordHasherService : IPasswordHasher
{
    private readonly PasswordHasher<object> _passwordHasher = new();

    public string Hash(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException(
                "A senha não pode ser vazia.",
                nameof(password));
        }

        return _passwordHasher.HashPassword(
            new object(),
            password);
    }

    public bool Verify(
        string passwordHash,
        string password)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            return false;

        if (string.IsNullOrWhiteSpace(password))
            return false;

        var result =
            _passwordHasher.VerifyHashedPassword(
                new object(),
                passwordHash,
                password);

        return result != PasswordVerificationResult.Failed;
    }
}