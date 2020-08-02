using MS.Lib.Config.Abstractions;
using MS.Lib.Data.Abstractions.Attributes;
using MS.Lib.Data.Core.Entities;

namespace MS.Module.Admin.Domain.Config
{
    /// <summary>
    /// 配置项
    /// </summary>
    [Table("Config")]
    public partial class ConfigEntity : Entity<int>
    {
        /// <summary>
        /// 类型
        /// </summary>
        public ConfigType Type { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Max]
        [Nullable]
        public string Value { get; set; }
    }
}