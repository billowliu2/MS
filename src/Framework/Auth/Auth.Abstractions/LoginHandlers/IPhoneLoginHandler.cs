using MS.Lib.Auth.Abstractions.LoginModels;
using System.Threading.Tasks;

namespace MS.Lib.Auth.Abstractions.LoginHandlers
{
    /// <summary>
    /// 手机登录处理
    /// </summary>
    public interface IPhoneLoginHandler
    {
        /// <summary>
        /// 登录处理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<LoginResultModel> Handle(PhoneLoginModel model);
    }
}