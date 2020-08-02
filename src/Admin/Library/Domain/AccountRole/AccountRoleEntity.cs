using MS.Lib.Data.Abstractions.Attributes;
using MS.Lib.Data.Core.Entities;
using System;

namespace MS.Module.Admin.Domain.AccountRole
{
    /// <summary>
    /// 账户角色
    /// </summary>
    [Table("Account_Role")]
    public class AccountRoleEntity : Entity<int>
    {
        /// <summary>
        /// 账户编号
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleId { get; set; }
    }
}