using MS.Lib.Data.Query;
using MS.Lib.Utils.Core.Result;
using System.Collections.Generic;

namespace MS.Lib.Excel.Abstractions
{
    /// <summary>
    /// Excel处理接口
    /// </summary>
    public interface IExcelHandler
    {
        /// <summary>
        /// 导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        ExcelExportResultModel Export<T>(ExportModel model, IList<T> entities) where T : class, new();
    }
}