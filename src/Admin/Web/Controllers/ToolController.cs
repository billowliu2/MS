using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MS.Lib.Auth.Abstractions;
using MS.Lib.Auth.Abstractions.LoginModels;
using MS.Lib.Auth.Web.Attributes;
using MS.Lib.Config.Abstractions;
using MS.Lib.Utils.Core.Helpers;
using MS.Module.Admin.Application.ToolService;
using System.ComponentModel;

namespace MS.Module.Admin.Web.Controllers
{
    [Description("通用工具")]
    [Common]
    [DisableAuditing]
    public class ToolController : Web.ModuleController
    {
        private readonly IToolService _service;

        public ToolController(IToolService service, FileUploadHelper fileUploadHelper, IConfigProvider configProvider)
        {
            _service = service;
        }

        [HttpGet]
        [Description("通用枚举下拉列表")]
        public IResultModel EnumSelect([BindRequired] string moduleCode, [BindRequired] string enumName, string libName = "Domain")
        {
            return _service.GetEnumSelect(moduleCode, enumName, libName);
        }

        [HttpGet]
        [Description("平台类型下拉列表")]
        public IResultModel PlatformSelect()
        {
            return ResultModel.Success(EnumExtensions.ToResult<Platform>());
        }

        [HttpGet]
        [Description("登录模式下拉列表")]
        public IResultModel LoginModeSelect()
        {
            return ResultModel.Success(EnumExtensions.ToResult<LoginMode>());
        }
    }
}