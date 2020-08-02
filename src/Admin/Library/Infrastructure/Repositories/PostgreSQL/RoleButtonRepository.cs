using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.PostgreSQL
{
    public class RoleButtonRepository : SqlServer.RoleButtonRepository
    {
        public RoleButtonRepository(IDbContext context) : base(context)
        {
        }
    }
}