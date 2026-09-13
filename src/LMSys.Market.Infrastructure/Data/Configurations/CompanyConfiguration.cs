using LMSys.Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMSys.Market.Infrastructure.Data.Configurations;

public sealed class CompanyConfiguration
    : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("companies");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.LegalName)
            .HasColumnName("legal_name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.TradeName)
            .HasColumnName("trade_name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Document)
            .HasColumnName("document")
            .HasMaxLength(20);

        builder.Property(x => x.StateRegistration)
            .HasColumnName("state_registration")
            .HasMaxLength(30);

        builder.Property(x => x.Phone)
            .HasColumnName("phone")
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(150);

        builder.Property(x => x.Address)
            .HasColumnName("address")
            .HasMaxLength(250);

        builder.Property(x => x.City)
            .HasColumnName("city")
            .HasMaxLength(100);

        builder.Property(x => x.State)
            .HasColumnName("state")
            .HasMaxLength(2);

        builder.Property(x => x.ZipCode)
            .HasColumnName("zip_code")
            .HasMaxLength(10);

        builder.Property(x => x.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasIndex(x => x.Document)
            .HasDatabaseName("ix_companies_document");
    }
}