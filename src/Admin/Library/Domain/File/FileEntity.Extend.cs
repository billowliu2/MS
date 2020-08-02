using MS.Lib.Data.Abstractions.Attributes;

namespace MS.Module.Admin.Domain.File
{
    public partial class FileEntity
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        [Ignore]
        public string ModuleName { get; set; }

        /// <summary>
        /// 访问URL
        /// </summary>
        [Ignore]
        public string Url { get; set; }

        [Ignore]
        public string AccessModeName => AccessMode.ToDescription();
    }
}