using Microsoft.AspNetCore.Mvc;
using MS.Lib.Validation.Abstractions;

namespace MS.Lib.Auth.Web
{
    /// <summary>
    /// 公共接口抽象控制器
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [ValidateResultFormat]
    public abstract class ApiControllerAbstract : ControllerBase
    {
    }
}