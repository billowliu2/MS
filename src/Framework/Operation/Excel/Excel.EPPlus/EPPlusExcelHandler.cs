using MS.Lib.Auth.Abstractions;
using MS.Lib.Config.Abstractions;
using MS.Lib.Excel.Abstractions;

namespace MS.Lib.Excel.EPPlus
{
    public class EPPlusExcelHandler : ExcelHandlerAbstract
    {
        public EPPlusExcelHandler(ILoginInfo loginInfo, IExcelExportHandler exportHandler, ExcelConfig config, IConfigProvider configProvider) : base(loginInfo, exportHandler, config, configProvider)
        {
        }
    }
}