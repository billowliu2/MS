using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.SQLite
{
    public class ConfigRepository : SqlServer.ConfigRepository
    {
        public ConfigRepository(IDbContext context) : base(context)
        {
        }
    }
}