using MS.Lib.Auth.Abstractions.LoginModels;
using System.Threading.Tasks;

namespace MS.Lib.Auth.Abstractions
{
    /// <summary>
    /// 租户解析器接口
    /// </summary>
    public interface ITenantResolver
    {
        /// <summary>
        /// 解析租户ID
        /// </summary>
        /// <param name="loginResultModel">登录结果</param>
        /// <returns></returns>
        Task Resolve(LoginResultModel loginResultModel);
    }
}