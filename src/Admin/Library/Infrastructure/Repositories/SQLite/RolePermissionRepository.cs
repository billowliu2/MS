using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.SQLite
{
    public class RolePermissionRepository : SqlServer.RolePermissionRepository
    {
        public RolePermissionRepository(IDbContext context) : base(context)
        {
        }
    }
}