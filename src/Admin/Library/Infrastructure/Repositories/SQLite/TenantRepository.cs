using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.SQLite
{
    public class TenantRepository : SqlServer.TenantRepository
    {
        public TenantRepository(IDbContext context) : base(context)
        {
        }
    }
}