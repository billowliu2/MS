using MS.Lib.Auth.Abstractions.LoginModels;
using System.Threading.Tasks;

namespace MS.Lib.Auth.Abstractions.Providers
{
    /// <summary>
    /// 登录日志处理
    /// </summary>
    public interface ILoginLogProvider
    {
        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="loginResult">登录结果</param>
        /// <returns></returns>
        Task Handle(LoginResultModel loginResult);
    }
}