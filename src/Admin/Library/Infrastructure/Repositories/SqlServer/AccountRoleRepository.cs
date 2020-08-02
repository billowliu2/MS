using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Module.Admin.Domain.Account;
using MS.Module.Admin.Domain.AccountRole;
using MS.Module.Admin.Domain.Role;
using MS.Module.Admin.Domain.RoleMenu;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class AccountRoleRepository : RepositoryAbstract<AccountRoleEntity>, IAccountRoleRepository
    {
        public AccountRoleRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> Delete(Guid accountId, Guid roleId)
        {
            return Db.Find(m => m.AccountId == accountId && m.RoleId == roleId).DeleteAsync();
        }

        public Task<bool> DeleteByAccount(Guid accountId, IUnitOfWork uow)
        {
            return Db.Find(m => m.AccountId == accountId).UseUow(uow).DeleteAsync();
        }

        public Task<bool> Exists(Guid accountId, Guid roleId)
        {
            return Db.Find(m => m.AccountId == accountId && m.RoleId == roleId).ExistsAsync();
        }

        public Task<IList<RoleEntity>> QueryRole(Guid accountId)
        {
            return Db.Find(m => m.AccountId == accountId)
                .InnerJoin<RoleEntity>((x, y) => x.RoleId == y.Id)
                .Select((x, y) => new { y })
                .ToListAsync<RoleEntity>();
        }

        public Task<IList<AccountRoleEntity>> QueryByRole(Guid roleId)
        {
            return Db.Find(m => m.RoleId == roleId).ToListAsync();
        }

        public Task<IList<AccountRoleEntity>> QueryByMenu(Guid menuId)
        {
            return Db.Find()
                .InnerJoin<RoleMenuEntity>((x, y) => x.RoleId == y.RoleId)
                .Where((x, y) => y.MenuId == menuId)
                .ToListAsync();
        }

        public Task<bool> ExistsByRole(Guid roleId)
        {
            return Db.Find(m => m.RoleId == roleId).InnerJoin<AccountEntity>((x, y) => x.AccountId == y.Id && y.Deleted == false).ExistsAsync();
        }
    }
}