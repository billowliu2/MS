using MS.Lib.Data.Abstractions;
using MS.Module.Admin.Domain.Role.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Domain.Role
{
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : IRepository<RoleEntity>
    {
        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Exists(string name, Guid? id = null);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<RoleEntity>> Query(RoleQueryModel model);
    }
}