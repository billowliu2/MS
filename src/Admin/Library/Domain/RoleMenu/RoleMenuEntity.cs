using MS.Lib.Data.Abstractions.Attributes;
using MS.Lib.Data.Core.Entities;
using System;

namespace MS.Module.Admin.Domain.RoleMenu
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    [Table("Role_Menu")]
    public partial class RoleMenuEntity : Entity<int>
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public Guid MenuId { get; set; }
    }
}