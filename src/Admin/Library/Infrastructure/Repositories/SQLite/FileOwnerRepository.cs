using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.SQLite
{
    public class FileOwnerRepository : SqlServer.FileOwnerRepository
    {
        public FileOwnerRepository(IDbContext context) : base(context)
        {
        }
    }
}