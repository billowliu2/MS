using MS.Lib.Auth.Abstractions;
using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Module.Admin.Domain.AccountRole;
using MS.Module.Admin.Domain.RolePermission;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class RolePermissionRepository : RepositoryAbstract<RolePermissionEntity>, IRolePermissionRepository
    {
        public RolePermissionRepository(IDbContext context) : base(context)
        {
        }

        public Task<IList<string>> QueryByRole(Guid roleId, Platform platform)
        {
            return Db.Find(m => m.RoleId == roleId && m.Platform == platform).Select(m => m.PermissionCode).ToListAsync<string>();
        }

        public Task<IList<string>> QueryByAccount(Guid accountId, Platform platform)
        {
            return Db.Find(m => m.Platform == platform)
                .InnerJoin<AccountRoleEntity>((x, y) => x.RoleId == y.RoleId && y.AccountId == accountId)
                .Select((x, y) => x.PermissionCode)
                .ToListAsync<string>();
        }

        public Task<bool> DeleteByRole(Guid roleId, Platform platform, IUnitOfWork uow = null)
        {
            return Db.Find(m => m.RoleId == roleId && m.Platform == platform).UseUow(uow).DeleteAsync();
        }
    }
}