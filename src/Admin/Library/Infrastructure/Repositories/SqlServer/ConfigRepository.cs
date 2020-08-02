using MS.Lib.Config.Abstractions;
using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Module.Admin.Domain.Config;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class ConfigRepository : RepositoryAbstract<ConfigEntity>, IConfigRepository
    {
        public ConfigRepository(IDbContext context) : base(context)
        {
        }

        public Task<ConfigEntity> Get(ConfigType type, string code)
        {
            return GetAsync(m => m.Type == type && m.Code == code);
        }
    }
}