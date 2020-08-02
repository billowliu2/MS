using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Lib.Data.Query;
using MS.Module.Admin.Domain.Account;
using MS.Module.Admin.Domain.AccountRole;
using MS.Module.Admin.Domain.Menu;
using MS.Module.Admin.Domain.Menu.Models;
using MS.Module.Admin.Domain.RoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class MenuRepository : RepositoryAbstract<MenuEntity>, IMenuRepository
    {
        public MenuRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<MenuEntity>> Query(MenuQueryModel model)
        {
            var paging = model.Paging();
            var query = Db.Find();
            query.WhereNotNull(model.Name, m => m.Name.Contains(model.Name));
            query.WhereNotNull(model.RouteName, m => m.RouteName.Contains(model.RouteName));

            if (model.ParentId == null)
                model.ParentId = Guid.Empty;

            query.Where(m => m.ParentId == model.ParentId);

            var joinQuery = query.LeftJoin<AccountEntity>((x, y) => x.CreatedBy == y.Id);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderBy((x, y) => x.Sort);
            }

            joinQuery.Select((x, y) => new { x, CreatorName = y.Name });
            var list = await joinQuery.PaginationAsync(paging);
            model.TotalCount = paging.TotalCount;
            return list;
        }

        public Task<IList<MenuEntity>> QueryChildren(Guid parentId)
        {
            return Db.Find(m => m.ParentId == parentId).OrderBy(m => m.Sort).ToListAsync();
        }

        public Task<bool> ExistsChild(Guid id)
        {
            return ExistsAsync(e => e.ParentId == id);
        }

        public Task<MenuEntity> GetAsync(Guid id)
        {
            var query = Db.Find().LeftJoin<MenuEntity>((x, y) => x.ParentId == y.Id)
                .LeftJoin<AccountEntity>((x, y, z) => x.CreatedBy == z.Id)
                .Where((x, y, z) => x.Id == id)
                .Select((m, n, o) => new { m, ParentName = n.Name, });

            return query.FirstAsync<MenuEntity>();
        }

        public Task<IList<MenuEntity>> QueryByAccount(Guid accountId)
        {
            return Db.Find().InnerJoin<RoleMenuEntity>((x, y) => x.Id == y.MenuId)
                 .InnerJoin<AccountRoleEntity>((x, y, z) => y.RoleId == z.RoleId && z.AccountId == accountId)
                 .Select((x, y, z) => new { x })
                 .ToListAsync();
        }

        public Task<IList<MenuEntity>> QueryByRole(Guid roleId)
        {
            return Db.Find().InnerJoin<RoleMenuEntity>((x, y) => x.Id == y.MenuId && y.RoleId == roleId)
                .Select((x, y) => new { x })
                .ToListAsync();
        }
    }
}