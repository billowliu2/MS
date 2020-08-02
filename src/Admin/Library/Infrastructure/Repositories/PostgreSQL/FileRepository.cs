using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.PostgreSQL
{
    public class FileRepository : SqlServer.FileRepository
    {
        public FileRepository(IDbContext context) : base(context)
        {
        }
    }
}