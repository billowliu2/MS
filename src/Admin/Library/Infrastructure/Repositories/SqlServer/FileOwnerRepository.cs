using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Module.Admin.Domain.FileOwner;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class FileOwnerRepository : RepositoryAbstract<FileOwnerEntity>, IFileOwnerRepository
    {
        public FileOwnerRepository(IDbContext context) : base(context)
        {
        }

        public Task<bool> Exist(FileOwnerEntity entity)
        {
            return Db.Find(m => m.SaveId == entity.SaveId && m.AccountId == entity.AccountId).ExistsAsync();
        }
    }
}