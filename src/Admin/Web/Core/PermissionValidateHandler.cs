using MS.Lib.Auth.Abstractions;
using MS.Lib.Utils.Core.Attributes;
using MS.Lib.Utils.Core.Enums;
using MS.Module.Admin.Infrastructure.AccountPermissionResolver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Module.Admin.Web.Core
{
    /// <summary>
    /// 权限验证
    /// </summary>
    [Singleton]
    public class PermissionValidateHandler : IPermissionValidateHandler
    {
        private readonly ILoginInfo _loginInfo;
        private readonly IAccountPermissionResolver _permissionResolver;

        public PermissionValidateHandler(ILoginInfo loginInfo, IAccountPermissionResolver permissionResolver)
        {
            _loginInfo = loginInfo;
            _permissionResolver = permissionResolver;
        }

        public async Task<bool> Validate(IDictionary<string, string> routeValues, HttpMethod httpMethod)
        {
            var permissions = await _permissionResolver.Resolve(_loginInfo.AccountId, _loginInfo.Platform);

            var area = routeValues["area"];
            var controller = routeValues["controller"];
            var action = routeValues["action"];
            return permissions.Any(m => m.EqualsIgnoreCase($"{area}_{controller}_{action}_{httpMethod}"));
        }
    }
}