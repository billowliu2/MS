using MS.Lib.Data.Abstractions.Attributes;
using MS.Lib.Data.Core.Entities;
using System;

namespace MS.Module.Admin.Domain.RolePage
{
    /// <summary>
    /// 角色绑定的页面
    /// </summary>
    [Table("Role_Page")]
    public class RolePageEntity : Entity<int>
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 页面编码(对应前端路由名称)
        /// </summary>
        [Length(200)]
        public string PageCode { get; set; }
    }
}