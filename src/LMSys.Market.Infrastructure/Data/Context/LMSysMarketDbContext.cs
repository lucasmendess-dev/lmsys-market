using LMSys.Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMSys.Market.Infrastructure.Data.Context;

public sealed class LMSysMarketDbContext : DbContext
{
    public LMSysMarketDbContext(
        DbContextOptions<LMSysMarketDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Store> Stores => Set<Store>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    public DbSet<UserStore> UserStores => Set<UserStore>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(LMSysMarketDbContext).Assembly);
    }
}