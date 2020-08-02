using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;

namespace MS.Module.Admin.Infrastructure.Repositories
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(IDbContextOptions options) : base(options)
        {
        }
    }
}