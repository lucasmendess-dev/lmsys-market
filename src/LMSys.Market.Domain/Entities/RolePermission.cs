using LMSys.Market.Domain.Common;

namespace LMSys.Market.Domain.Entities;

public sealed class RolePermission
{
    public long RoleId { get; private set; }

    public long PermissionId { get; private set; }

    private RolePermission()
    {
    }

    public RolePermission(
        long roleId,
        long permissionId)
    {
        RoleId = Guard.PositiveId(roleId, "Perfil");
        PermissionId = Guard.PositiveId(
            permissionId,
            "Permissão");
    }
}