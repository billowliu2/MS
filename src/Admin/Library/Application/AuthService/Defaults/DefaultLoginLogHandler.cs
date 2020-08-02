using MS.Lib.Auth.Abstractions;
using MS.Lib.Auth.Abstractions.LoginModels;
using MS.Lib.Auth.Abstractions.Providers;
using MS.Lib.Utils.Core.Attributes;
using MS.Module.Admin.Domain.LoginLog;
using System.Threading.Tasks;

namespace MS.Module.Admin.Application.AuthService.Defaults
{
    [Singleton]
    internal class DefaultLoginLogHandler : ILoginLogProvider
    {
        private readonly ILoginLogRepository _repository;
        private readonly ILoginInfo _loginInfo;

        public DefaultLoginLogHandler(ILoginLogRepository repository, ILoginInfo loginInfo)
        {
            _repository = repository;
            _loginInfo = loginInfo;
        }

        public Task Handle(LoginResultModel model)
        {
            var entity = new LoginLogEntity
            {
                AccountId = model.AccountId,
                UserName = model.UserName,
                Email = model.Email,
                Error = model.Error,
                LoginMode = model.LoginMode,
                LoginTime = model.LoginTime,
                Phone = model.Phone,
                Platform = model.Platform,
                Success = model.Success,
                IP = _loginInfo.IP,
                UserAgent = _loginInfo.UserAgent
            };
            return _repository.AddAsync(entity);
        }
    }
}