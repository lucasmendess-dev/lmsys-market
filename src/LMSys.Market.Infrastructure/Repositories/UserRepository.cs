using LMSys.Market.Application.DTOs;
using LMSys.Market.Application.Interfaces;
using LMSys.Market.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LMSys.Market.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly LMSysMarketDbContext _dbContext;

    public UserRepository(
        LMSysMarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserAuthenticationData?>
        GetForAuthenticationAsync(
            string identifier,
            CancellationToken cancellationToken = default)
    {
        var user =
            await _dbContext.Users
                .FirstOrDefaultAsync(
                    x =>
                        x.Username == identifier ||
                        x.Email == identifier,
                    cancellationToken);

        if (user is null)
            return null;

        var roleName =
            await _dbContext.Roles
                .Where(x => x.Id == user.RoleId)
                .Select(x => x.Name)
                .FirstOrDefaultAsync(
                    cancellationToken);

        if (string.IsNullOrWhiteSpace(roleName))
            return null;

        var store =
            await (
                from userStore in _dbContext.UserStores

                join storeEntity in _dbContext.Stores
                    on userStore.StoreId equals storeEntity.Id

                where
                    userStore.UserId == user.Id &&
                    storeEntity.IsActive

                orderby storeEntity.Id

                select new
                {
                    storeEntity.Id,
                    storeEntity.Name
                })
                .FirstOrDefaultAsync(
                    cancellationToken);

        if (store is null)
            return null;

        var permissions =
            await (
                from rolePermission
                    in _dbContext.RolePermissions

                join permission
                    in _dbContext.Permissions
                    on rolePermission.PermissionId
                    equals permission.Id

                where
                    rolePermission.RoleId == user.RoleId

                orderby permission.Code

                select permission.Code)
                .ToListAsync(
                    cancellationToken);

        return new UserAuthenticationData(
            User: user,
            RoleName: roleName,
            StoreId: store.Id,
            StoreName: store.Name,
            Permissions: permissions);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}