using MS.Lib.Data.Abstractions.Attributes;
using MS.Lib.Data.Core.Entities;
using System;

namespace MS.Module.Admin.Domain.FileOwner
{
    /// <summary>
    /// 文件所有者信息
    /// </summary>
    [Table("File_Owner")]
    public class FileOwnerEntity : Entity<long>
    {
        /// <summary>
        /// 文件存储编号
        /// </summary>
        public string SaveId { get; set; }

        /// <summary>
        /// 账户编号
        /// </summary>
        public Guid AccountId { get; set; }
    }
}