using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.MySql
{
    public class RoleMenuRepository : SqlServer.RoleMenuRepository
    {
        public RoleMenuRepository(IDbContext context) : base(context)
        {
        }
    }
}