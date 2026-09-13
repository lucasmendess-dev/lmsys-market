using LMSys.Market.Domain.Common;

namespace LMSys.Market.Domain.Entities;

public sealed class Company : Entity
{
    public string LegalName { get; private set; } = string.Empty;

    public string TradeName { get; private set; } = string.Empty;

    public string? Document { get; private set; }

    public string? StateRegistration { get; private set; }

    public string? Phone { get; private set; }

    public string? Email { get; private set; }

    public string? Address { get; private set; }

    public string? City { get; private set; }

    public string? State { get; private set; }

    public string? ZipCode { get; private set; }

    public bool IsActive { get; private set; }

    private Company()
    {
    }

    public Company(
        string legalName,
        string tradeName,
        string? document,
        string? stateRegistration,
        string? phone,
        string? email,
        string? address,
        string? city,
        string? state,
        string? zipCode,
        DateTimeOffset createdAt)
        : base(createdAt)
    {
        LegalName = Guard.Required(legalName, "Razão social", 150);
        TradeName = Guard.Required(tradeName, "Nome fantasia", 150);

        SetOptionalData(
            document,
            stateRegistration,
            phone,
            email,
            address,
            city,
            state,
            zipCode);

        IsActive = true;
    }

    public void Update(
        string legalName,
        string tradeName,
        string? document,
        string? stateRegistration,
        string? phone,
        string? email,
        string? address,
        string? city,
        string? state,
        string? zipCode,
        DateTimeOffset updatedAt)
    {
        LegalName = Guard.Required(legalName, "Razão social", 150);
        TradeName = Guard.Required(tradeName, "Nome fantasia", 150);

        SetOptionalData(
            document,
            stateRegistration,
            phone,
            email,
            address,
            city,
            state,
            zipCode);

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

    private void SetOptionalData(
        string? document,
        string? stateRegistration,
        string? phone,
        string? email,
        string? address,
        string? city,
        string? state,
        string? zipCode)
    {
        Document = Guard.Optional(document, "Documento", 20);
        StateRegistration = Guard.Optional(
            stateRegistration,
            "Inscrição estadual",
            30);

        Phone = Guard.Optional(phone, "Telefone", 30);
        Email = Guard.Optional(email, "E-mail", 150);
        Address = Guard.Optional(address, "Endereço", 250);
        City = Guard.Optional(city, "Cidade", 100);
        State = Guard.Optional(state, "Estado", 2);
        ZipCode = Guard.Optional(zipCode, "CEP", 10);
    }
}