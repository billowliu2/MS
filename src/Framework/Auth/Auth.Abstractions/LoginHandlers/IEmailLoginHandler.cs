using MS.Lib.Auth.Abstractions.LoginModels;
using System.Threading.Tasks;

namespace MS.Lib.Auth.Abstractions.LoginHandlers
{
    /// <summary>
    /// 邮件登录处理
    /// </summary>
    public interface IEmailLoginHandler
    {
        /// <summary>
        /// 登录处理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<LoginResultModel> Handle(EmailLoginModel model);
    }
}