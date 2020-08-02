﻿using MS.Lib.Excel.Abstractions;
using MS.Lib.Utils.Core.Result;
using MS.Module.Admin.Domain.LoginLog;
using MS.Module.Admin.Domain.LoginLog.Models;
using System.Threading.Tasks;

namespace MS.Module.Admin.Application.LogService
{
    public class LogService : ILogService
    {
        private readonly ILoginLogRepository _loginLogRepository;
        private readonly IExcelHandler _excelHandler;

        public LogService(ILoginLogRepository loginLogRepository, IExcelHandler excelHandler)
        {
            _loginLogRepository = loginLogRepository;
            _excelHandler = excelHandler;
        }

        public async Task<IResultModel> QueryLogin(LoginLogQueryModel model)
        {
            var result = new QueryResultModel<LoginLogEntity>
            {
                Rows = await _loginLogRepository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel<ExcelExportResultModel>> ExportLogin(LoginLogQueryModel model)
        {
            var result = new ResultModel<ExcelExportResultModel>();
            var list = await _loginLogRepository.Query(model);
            if (model.IsOutOfExportCountLimit)
            {
                return result.Failed($"导出数据不能超过{model.ExportCountLimit}条");
            }

            return result.Success(_excelHandler.Export(model.Export, list));
        }
    }
}