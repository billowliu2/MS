using Microsoft.AspNetCore.Mvc;
using MS.Module.Admin.Application.LogService;
using MS.Module.Admin.Domain.LoginLog.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MS.Module.Admin.Web.Controllers
{
    [Description("日志管理")]
    public class LogController : Web.ModuleController
    {
        private readonly ILogService _service;

        public LogController(ILogService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询登录日志")]
        public Task<IResultModel> Login([FromQuery] LoginLogQueryModel model)
        {
            return _service.QueryLogin(model);
        }

        [HttpPost]
        [Description("导出登录日志")]
        public async Task<IActionResult> LoginExport(LoginLogQueryModel model)
        {
            var result = await _service.ExportLogin(model);
            if (result.Successful)
            {
                return ExportExcel(result.Data.Path, result.Data.FileName);
            }

            return Ok(result);
        }
    }
}