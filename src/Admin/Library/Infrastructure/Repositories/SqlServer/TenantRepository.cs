using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Module.Admin.Domain.Tenant;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class TenantRepository : RepositoryAbstract<TenantEntity>, ITenantRepository
    {
        public TenantRepository(IDbContext context) : base(context)
        {
        }
    }
}