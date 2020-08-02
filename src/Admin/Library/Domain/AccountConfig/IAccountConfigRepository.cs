using MS.Lib.Data.Abstractions;
using System;
using System.Threading.Tasks;

namespace MS.Module.Admin.Domain.AccountConfig
{
    /// <summary>
    /// 账户配置仓储
    /// </summary>
    public interface IAccountConfigRepository : IRepository<AccountConfigEntity>
    {
        /// <summary>
        /// 查询指定账户的配置信息
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<AccountConfigEntity> GetByAccount(Guid accountId);
    }
}