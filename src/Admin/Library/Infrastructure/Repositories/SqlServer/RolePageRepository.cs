using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Module.Admin.Domain.AccountRole;
using MS.Module.Admin.Domain.RolePage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class RolePageRepository : RepositoryAbstract<RolePageEntity>, IRolePageRepository
    {
        public RolePageRepository(IDbContext context) : base(context)
        {
        }

        public Task<IList<string>> QueryPageCodesByRole(Guid roleId)
        {
            return Db.Find(m => m.RoleId == roleId).Select(m => m.PageCode).ToListAsync<string>();
        }

        public Task<IList<string>> QueryPageCodesByAccount(Guid accountId)
        {
            return Db.Find()
                .LeftJoin<AccountRoleEntity>((x, y) => x.RoleId == y.RoleId && y.AccountId == accountId)
                .Select((x, y) => x.PageCode)
                .ToListAsync<string>();
        }

        public Task<bool> DeleteByRole(Guid roleId, IUnitOfWork uow = null)
        {
            return Db.Find(m => m.RoleId == roleId).UseUow(uow).DeleteAsync();
        }
    }
}