using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Lib.Data.Query;
using MS.Module.Admin.Domain.Mime;
using MS.Module.Admin.Domain.Mime.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class MimeRepository : RepositoryAbstract<MimeEntity>, IMimeRepository
    {
        public MimeRepository(IDbContext context) : base(context)
        {
        }

        public Task<MimeEntity> Get(string ext)
        {
            return GetAsync(m => m.Ext == ext);
        }

        public async Task<IList<MimeEntity>> Query(MimeQueryModel model)
        {
            var paging = model.Paging();
            var query = Db.Find();
            query.WhereNotNull(model.Ext, m => m.Ext.Contains(model.Ext));

            if (!paging.OrderBy.Any())
            {
                query.OrderByDescending(m => m.Id);
            }

            var list = await query.PaginationAsync(paging);
            model.TotalCount = paging.TotalCount;
            return list;
        }

        public Task<bool> Exists(MimeEntity entity)
        {
            var query = Db.Find(m => m.Ext == entity.Ext);
            query.WhereIf(entity.Id > 0, m => m.Id != entity.Id);
            return query.ExistsAsync();
        }
    }
}