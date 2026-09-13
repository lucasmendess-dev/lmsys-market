using LMSys.Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMSys.Market.Infrastructure.Data.Configurations;

public sealed class UserStoreConfiguration
    : IEntityTypeConfiguration<UserStore>
{
    public void Configure(
        EntityTypeBuilder<UserStore> builder)
    {
        builder.ToTable("user_stores");

        builder.HasKey(x => new
        {
            x.UserId,
            x.StoreId
        });

        builder.Property(x => x.UserId)
            .HasColumnName("user_id");

        builder.Property(x => x.StoreId)
            .HasColumnName("store_id");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Store>()
            .WithMany()
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}