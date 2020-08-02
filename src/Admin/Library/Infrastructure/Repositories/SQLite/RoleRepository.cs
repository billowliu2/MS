using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.SQLite
{
    public class RoleRepository : SqlServer.RoleRepository
    {
        public RoleRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}