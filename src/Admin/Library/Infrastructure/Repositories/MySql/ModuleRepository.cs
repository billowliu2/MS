using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.MySql
{
    public class ModuleRepository : SqlServer.ModuleRepository
    {
        public ModuleRepository(IDbContext context) : base(context)
        {
        }
    }
}