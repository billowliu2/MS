using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.PostgreSQL
{
    public class RoleMenuRepository : SqlServer.RoleMenuRepository
    {
        public RoleMenuRepository(IDbContext context) : base(context)
        {
        }
    }
}