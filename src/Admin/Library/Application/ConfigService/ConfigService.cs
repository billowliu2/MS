using MS.Lib.Auth.Abstractions;
using MS.Lib.Config.Abstractions;
using MS.Lib.Config.Abstractions.Impl;
using MS.Module.Admin.Application.ConfigService.ResultModels;
using MS.Module.Admin.Application.ConfigService.ViewModels;
using MS.Module.Admin.Domain.Config;

namespace MS.Module.Admin.Application.ConfigService
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _repository;
        private readonly IConfigProvider _configProvider;

        public ConfigService(IConfigRepository repository, IConfigProvider configProvider)
        {
            _repository = repository;
            _configProvider = configProvider;
        }

        //public async Task<IResultModel> Query(ConfigQueryModel model)
        //{
        //    var result = new QueryResultModel<ConfigEntity>
        //    {
        //        Rows = await _repository.Query(model),
        //        Total = model.TotalCount
        //    };

        //    return ResultModel.Success(result);
        //}

        public UIConfigResultModel GetUI()
        {
            var result = new UIConfigResultModel();

            #region ==系统信息==

            var systemConfig = _configProvider.Get<SystemConfig>();
            result.System = new UISystem
            {
                Title = systemConfig.Title,
                Logo = systemConfig.Logo,
                Copyright = systemConfig.Copyright
            };

            #endregion ==系统信息==

            #region ==权限配置==

            var authConfig = _configProvider.Get<AuthConfig>();
            result.Permission = new UIPermission
            {
                Validate = authConfig.Validate,
                Button = authConfig.Button
            };

            #endregion ==权限配置==

            #region ==组件配置==

            result.Component = _configProvider.Get<ComponentConfig>();
            result.Component.Login.VerifyCode = authConfig.VerifyCode;

            #endregion ==组件配置==

            return result;
        }

        public IResultModel Edit(string code, ConfigType type)
        {
            return ResultModel.Success(_configProvider.Get(code, type));
        }

        public IResultModel Update(ConfigUpdateModel model)
        {
            return ResultModel.Success(_configProvider.Set(model.Type, model.Code, model.Json));
        }
    }
}