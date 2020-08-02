using MS.Lib.Data.Abstractions.Attributes;

namespace MS.Module.Admin.Domain.Menu
{
    public partial class MenuEntity
    {
        /// <summary>
        /// 父节点名称
        /// </summary>
        [Ignore]
        public string ParentName { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        [Ignore]
        public string TypeName => Type.ToDescription();

        /// <summary>
        /// 打开方式名称
        /// </summary>
        [Ignore]
        public string TargetName => Target.ToDescription();
    }
}