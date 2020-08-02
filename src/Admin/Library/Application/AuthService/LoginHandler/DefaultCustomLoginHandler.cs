using MS.Lib.Auth.Abstractions.LoginHandlers;
using MS.Lib.Auth.Abstractions.LoginModels;
using MS.Lib.Utils.Core.Attributes;
using System;
using System.Threading.Tasks;

namespace MS.Module.Admin.Application.AuthService.LoginHandler
{
    /// <summary>
    /// 自定义登录默认实现
    /// </summary>
    [Singleton]
    public class DefaultCustomLoginHandler : ICustomLoginHandler
    {
        public Task<LoginResultModel> Handle(CustomLoginModel model)
        {
            throw new NotImplementedException();
        }
    }
}