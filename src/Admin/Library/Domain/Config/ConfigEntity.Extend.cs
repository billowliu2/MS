using MS.Lib.Data.Abstractions.Attributes;

namespace MS.Module.Admin.Domain.Config
{
    public partial class ConfigEntity
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        [Ignore]
        public string TypeName => Type.ToDescription();
    }
}