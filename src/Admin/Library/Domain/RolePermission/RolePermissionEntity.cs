using MS.Lib.Auth.Abstractions;
using MS.Lib.Data.Abstractions.Attributes;
using MS.Lib.Data.Core.Entities;
using System;

namespace MS.Module.Admin.Domain.RolePermission
{
    [Table("Role_Permission")]
    public class RolePermissionEntity : Entity<int>
    {
        /// <summary>
        /// 角色
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 平台类型
        /// </summary>
        public Platform Platform { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        [Length(200)]
        public string PermissionCode { get; set; }
    }
}