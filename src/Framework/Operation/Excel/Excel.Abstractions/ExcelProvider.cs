using System.ComponentModel;

namespace MS.Lib.Excel.Abstractions
{
    /// <summary>
    /// Excel操作库
    /// </summary>
    public enum ExcelProvider
    {
        [Description("EPPlus")]
        EPPlus,

        [Description("NPOI")]
        NPOI,

        [Description("OpenXml")]
        OpenXml
    }
}