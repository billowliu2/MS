using MS.Lib.Data.Abstractions;
using MS.Module.Admin.Domain.LoginLog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Domain.LoginLog
{
    /// <summary>
    /// 登录日志仓储
    /// </summary>
    public interface ILoginLogRepository : IRepository<LoginLogEntity>
    {
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<LoginLogEntity>> Query(LoginLogQueryModel model);
    }
}