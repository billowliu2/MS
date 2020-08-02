using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Lib.Data.Query;
using MS.Module.Admin.Domain.Account;
using MS.Module.Admin.Domain.File;
using MS.Module.Admin.Domain.File.Models;
using MS.Module.Admin.Domain.Module;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class FileRepository : RepositoryAbstract<FileEntity>, IFileRepository
    {
        public FileRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<FileEntity>> Query(FileQueryModel model)
        {
            var paging = model.Paging();
            var query = Db.Find();
            query.WhereNotNull(model.FileName, m => m.FileName.Contains(model.FileName));
            query.WhereNotNull(model.ModuleCode, m => m.ModuleCode == model.ModuleCode);
            query.WhereNotNull(model.AccessMode, m => m.AccessMode == model.AccessMode.Value);

            if (!paging.OrderBy.Any())
            {
                query.OrderByDescending(m => m.Id);
            }

            var list = await query.LeftJoin<ModuleEntity>((x, y) => x.ModuleCode == y.Code).LeftJoin<AccountEntity>((x, y, z) => x.CreatedBy == z.Id)
                .Select((x, y, z) => new { x, ModuleName = y.Name, Creator = z.Name })
                .PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;
            return list;
        }

        public Task<FileEntity> GetBySaveId(string saveId)
        {
            return GetAsync(m => m.SaveId == saveId);
        }
    }
}