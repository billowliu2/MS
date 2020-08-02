using MS.Lib.Config.Abstractions;
using MS.Lib.Data.Query;

namespace MS.Module.Admin.Domain.Config.Models
{
    public class ConfigQueryModel : QueryModel
    {
        public string Key { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public ConfigType? Type { get; set; }
    }
}