using LMSys.Market.Domain.Exceptions;

namespace LMSys.Market.Domain.Common;

public static class Guard
{
    public static string Required(
        string? value,
        string fieldName,
        int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"{fieldName} é obrigatório.");

        var normalizedValue = value.Trim();

        if (normalizedValue.Length > maxLength)
        {
            throw new DomainException(
                $"{fieldName} deve possuir no máximo {maxLength} caracteres.");
        }

        return normalizedValue;
    }

    public static string? Optional(
        string? value,
        string fieldName,
        int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var normalizedValue = value.Trim();

        if (normalizedValue.Length > maxLength)
        {
            throw new DomainException(
                $"{fieldName} deve possuir no máximo {maxLength} caracteres.");
        }

        return normalizedValue;
    }

    public static long PositiveId(long value, string fieldName)
    {
        if (value <= 0)
            throw new DomainException($"{fieldName} inválido.");

        return value;
    }
}