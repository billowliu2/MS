using MS.Lib.Auth.Abstractions;
using MS.Lib.Utils.Core.Attributes;
using MS.Module.Admin.Application.AuthService;
using System.Threading.Tasks;

namespace MS.Module.Admin.Web.Core
{
    [Singleton]
    public class SingleAccountLoginHandler : ISingleAccountLoginHandler
    {
        private readonly IAuthService _authService;
        private readonly ILoginInfo _loginInfo;

        public SingleAccountLoginHandler(IAuthService authService, ILoginInfo loginInfo)
        {
            _authService = authService;
            _loginInfo = loginInfo;
        }

        public async Task<bool> Validate()
        {
            var authInfo = await _authService.GetAuthInfo(_loginInfo.AccountId, _loginInfo.Platform);
            if (authInfo != null && authInfo.LoginTime != _loginInfo.LoginTime)
            {
                return true;
            }

            return false;
        }
    }
}