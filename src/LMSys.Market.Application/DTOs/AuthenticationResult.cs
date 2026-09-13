namespace LMSys.Market.Application.DTOs;

public sealed record AuthenticationResult(
    bool Succeeded,
    string? ErrorMessage)
{
    public static AuthenticationResult Success()
    {
        return new AuthenticationResult(
            true,
            null);
    }

    public static AuthenticationResult Failure(
        string errorMessage)
    {
        return new AuthenticationResult(
            false,
            errorMessage);
    }
}