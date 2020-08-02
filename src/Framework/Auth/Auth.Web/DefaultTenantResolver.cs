using MS.Lib.Auth.Abstractions;
using MS.Lib.Auth.Abstractions.LoginModels;
using MS.Lib.Utils.Core.Attributes;
using System.Threading.Tasks;

namespace MS.Lib.Auth.Web
{
    [Singleton]
    public class DefaultTenantResolver : ITenantResolver
    {
        public Task Resolve(LoginResultModel loginResultModel)
        {
            loginResultModel.TenantId = null;
            return Task.CompletedTask;
        }
    }
}