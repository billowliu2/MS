using MS.Lib.Quartz.Abstractions;
using MS.Module.Admin.Application.ModuleService;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MS.Module.Admin.Quartz
{
    [Description("模块接口请求数量同步")]
    public class ModuleApiRequestCountSyncTask : TaskAbstract
    {
        private readonly IModuleService _moduleService;

        public ModuleApiRequestCountSyncTask(ITaskLogger logger, IModuleService moduleService) : base(logger)
        {
            _moduleService = moduleService;
        }

        public override async Task Execute(ITaskExecutionContext context)
        {
            await _moduleService.SyncApiRequestCount();
        }
    }
}