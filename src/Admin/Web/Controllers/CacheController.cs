using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MS.Module.Admin.Application.CacheService;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MS.Module.Admin.Web.Controllers
{
    [Description("缓存管理")]
    public class CacheController : Web.ModuleController
    {
        private readonly ICacheService _service;

        public CacheController(ICacheService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询指定模块缓存键列表")]
        public IResultModel Query([BindRequired] string moduleCode)
        {
            return _service.Query(moduleCode);
        }

        [HttpDelete]
        [Description("清除指定前缀的缓存")]
        public Task<IResultModel> Clear([BindRequired] string prefix)
        {
            return _service.Clear(prefix);
        }
    }
}