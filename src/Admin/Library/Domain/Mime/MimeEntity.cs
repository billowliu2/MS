using MS.Lib.Data.Abstractions.Attributes;
using MS.Lib.Data.Core.Entities;

namespace MS.Module.Admin.Domain.Mime
{
    /// <summary>
    /// MIME 类型
    /// </summary>
    public class MimeEntity : Entity<int>
    {
        /// <summary>
        /// 后缀名
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Length(200)]
        public string Value { get; set; }
    }
}