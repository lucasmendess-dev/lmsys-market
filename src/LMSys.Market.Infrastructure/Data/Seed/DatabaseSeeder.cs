using LMSys.Market.Application.Interfaces;
using LMSys.Market.Domain.Entities;
using LMSys.Market.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LMSys.Market.Infrastructure.Data.Seed;

public sealed class DatabaseSeeder
{
    private readonly LMSysMarketDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;

    public DatabaseSeeder(
        LMSysMarketDbContext dbContext,
        IPasswordHasher passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    public async Task SeedAsync(
        CancellationToken cancellationToken = default)
    {
        var now = DateTimeOffset.UtcNow;

        var company = await SeedCompanyAsync(
            now,
            cancellationToken);

        var store = await SeedStoreAsync(
            company,
            now,
            cancellationToken);

        var roles = await SeedRolesAsync(
            now,
            cancellationToken);

        var permissions = await SeedPermissionsAsync(
            now,
            cancellationToken);

        await SeedAdministratorPermissionsAsync(
            roles,
            permissions,
            cancellationToken);

        await SeedAdministratorAsync(
            roles,
            store,
            now,
            cancellationToken);
    }

    private async Task<Company> SeedCompanyAsync(
        DateTimeOffset now,
        CancellationToken cancellationToken)
    {
        var company =
            await _dbContext.Companies
                .FirstOrDefaultAsync(
                    x => x.TradeName == "LMSys",
                    cancellationToken);

        if (company is not null)
            return company;

        company = new Company(
            legalName: "LMSys",
            tradeName: "LMSys",
            document: null,
            stateRegistration: null,
            phone: null,
            email: null,
            address: null,
            city: null,
            state: null,
            zipCode: null,
            createdAt: now);

        _dbContext.Companies.Add(company);

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return company;
    }

    private async Task<Store> SeedStoreAsync(
        Company company,
        DateTimeOffset now,
        CancellationToken cancellationToken)
    {
        var store =
            await _dbContext.Stores
                .FirstOrDefaultAsync(
                    x =>
                        x.CompanyId == company.Id &&
                        x.Code == "MAIN",
                    cancellationToken);

        if (store is not null)
            return store;

        store = new Store(
            companyId: company.Id,
            code: "MAIN",
            name: "Loja Principal",
            document: null,
            phone: null,
            email: null,
            address: null,
            city: null,
            state: null,
            zipCode: null,
            createdAt: now);

        _dbContext.Stores.Add(store);

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return store;
    }

    private async Task<Dictionary<string, Role>> SeedRolesAsync(
        DateTimeOffset now,
        CancellationToken cancellationToken)
    {
        var definitions =
            new Dictionary<string, string>
            {
                ["Administrator"] =
                    "Acesso administrativo completo.",

                ["Manager"] =
                    "Gerenciamento da operação.",

                ["Cashier"] =
                    "Operação de ponto de venda e caixa.",

                ["StockClerk"] =
                    "Operações de estoque.",

                ["Buyer"] =
                    "Fornecedores e compras.",

                ["Financial"] =
                    "Operações financeiras."
            };

        var existingRoles =
            await _dbContext.Roles
                .ToDictionaryAsync(
                    x => x.Name,
                    cancellationToken);

        foreach (var definition in definitions)
        {
            if (existingRoles.ContainsKey(definition.Key))
                continue;

            var role = new Role(
                name: definition.Key,
                description: definition.Value,
                createdAt: now);

            _dbContext.Roles.Add(role);

            existingRoles.Add(
                definition.Key,
                role);
        }

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return existingRoles;
    }

    private async Task<Dictionary<string, Permission>>
        SeedPermissionsAsync(
            DateTimeOffset now,
            CancellationToken cancellationToken)
    {
        var definitions =
            new Dictionary<string, string>
            {
                ["dashboard.view"] =
                    "Visualizar dashboard.",

                ["users.view"] =
                    "Visualizar usuários.",

                ["users.manage"] =
                    "Gerenciar usuários.",

                ["products.view"] =
                    "Visualizar produtos.",

                ["products.create"] =
                    "Cadastrar produtos.",

                ["products.edit"] =
                    "Editar produtos.",

                ["inventory.view"] =
                    "Visualizar estoque.",

                ["inventory.adjust"] =
                    "Realizar ajustes de estoque.",

                ["sales.view"] =
                    "Visualizar vendas.",

                ["sales.cancel"] =
                    "Cancelar vendas.",

                ["cash.open"] =
                    "Abrir caixa.",

                ["cash.withdraw"] =
                    "Realizar sangria.",

                ["cash.close"] =
                    "Fechar caixa.",

                ["financial.view"] =
                    "Visualizar informações financeiras.",

                ["settings.view"] =
                    "Visualizar configurações.",

                ["settings.manage"] =
                    "Alterar configurações."
            };

        var existingPermissions =
            await _dbContext.Permissions
                .ToDictionaryAsync(
                    x => x.Code,
                    cancellationToken);

        foreach (var definition in definitions)
        {
            if (existingPermissions.ContainsKey(
                    definition.Key))
            {
                continue;
            }

            var permission = new Permission(
                code: definition.Key,
                name: definition.Value,
                description: definition.Value,
                createdAt: now);

            _dbContext.Permissions.Add(permission);

            existingPermissions.Add(
                definition.Key,
                permission);
        }

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return existingPermissions;
    }

    private async Task SeedAdministratorPermissionsAsync(
        IReadOnlyDictionary<string, Role> roles,
        IReadOnlyDictionary<string, Permission> permissions,
        CancellationToken cancellationToken)
    {
        var administrator =
            roles["Administrator"];

        var existingPermissionIds =
            await _dbContext.RolePermissions
                .Where(
                    x => x.RoleId == administrator.Id)
                .Select(
                    x => x.PermissionId)
                .ToHashSetAsync(
                    cancellationToken);

        foreach (var permission in permissions.Values)
        {
            if (existingPermissionIds.Contains(
                    permission.Id))
            {
                continue;
            }

            _dbContext.RolePermissions.Add(
                new RolePermission(
                    administrator.Id,
                    permission.Id));
        }

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }

    private async Task SeedAdministratorAsync(
        IReadOnlyDictionary<string, Role> roles,
        Store store,
        DateTimeOffset now,
        CancellationToken cancellationToken)
    {
        const string defaultUsername = "admin";

        var existingUser =
            await _dbContext.Users
                .FirstOrDefaultAsync(
                    x => x.Username == defaultUsername,
                    cancellationToken);

        if (existingUser is not null)
        {
            await EnsureUserStoreAsync(
                existingUser.Id,
                store.Id,
                cancellationToken);

            return;
        }

        var password =
            Environment.GetEnvironmentVariable(
                "LMSYS_ADMIN_PASSWORD");

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidOperationException(
                "O usuário administrador ainda não existe. " +
                "Defina a variável de ambiente " +
                "LMSYS_ADMIN_PASSWORD antes de executar o seed.");
        }

        var administratorRole =
            roles["Administrator"];

        var passwordHash =
            _passwordHasher.Hash(password);

        var administrator = new User(
            name: "Administrador",
            username: defaultUsername,
            email: "admin@lmsys.local",
            passwordHash: passwordHash,
            roleId: administratorRole.Id,
            createdAt: now);

        _dbContext.Users.Add(administrator);

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        await EnsureUserStoreAsync(
            administrator.Id,
            store.Id,
            cancellationToken);
    }

    private async Task EnsureUserStoreAsync(
        long userId,
        long storeId,
        CancellationToken cancellationToken)
    {
        var exists =
            await _dbContext.UserStores
                .AnyAsync(
                    x =>
                        x.UserId == userId &&
                        x.StoreId == storeId,
                    cancellationToken);

        if (exists)
            return;

        _dbContext.UserStores.Add(
            new UserStore(
                userId,
                storeId));

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}