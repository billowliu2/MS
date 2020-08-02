using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.MySql
{
    public class RoleRepository : SqlServer.RoleRepository
    {
        public RoleRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}