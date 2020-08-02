using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.SQLite
{
    public class RoleButtonRepository : SqlServer.RoleButtonRepository
    {
        public RoleButtonRepository(IDbContext context) : base(context)
        {
        }
    }
}