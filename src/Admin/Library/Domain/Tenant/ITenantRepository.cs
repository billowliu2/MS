using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Domain.Tenant
{
    /// <summary>
    /// 租户仓储
    /// </summary>
    public interface ITenantRepository : IRepository<TenantEntity>
    {
    }
}