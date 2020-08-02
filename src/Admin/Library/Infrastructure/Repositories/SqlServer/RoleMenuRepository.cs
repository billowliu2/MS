using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Module.Admin.Domain.RoleMenu;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class RoleMenuRepository : RepositoryAbstract<RoleMenuEntity>, IRoleMenuRepository
    {
        public RoleMenuRepository(IDbContext context) : base(context)
        {
        }

        public Task<IList<RoleMenuEntity>> QueryByRoleId(Guid roleId)
        {
            return Db.Find(e => e.RoleId == roleId).ToListAsync();
        }

        public Task<bool> DeleteByMenuId(Guid menuId, IUnitOfWork uow)
        {
            return Db.Find(e => e.MenuId == menuId).UseUow(uow).DeleteAsync();
        }

        public Task<bool> ExistsWidthMenu(Guid menuId)
        {
            return Db.Find(e => e.MenuId == menuId).ExistsAsync();
        }

        public Task<bool> DeleteByRoleId(Guid roleId, IUnitOfWork uow)
        {
            return Db.Find(e => e.RoleId == roleId).UseUow(uow).DeleteAsync();
        }
    }
}