using MS.Lib.Config.Abstractions;
using MS.Lib.Data.Abstractions;
using System.Threading.Tasks;

namespace MS.Module.Admin.Domain.Config
{
    /// <summary>
    /// 配置项仓储
    /// </summary>
    public interface IConfigRepository : IRepository<ConfigEntity>
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="type"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<ConfigEntity> Get(ConfigType type, string code);
    }
}