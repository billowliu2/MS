using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.MySql
{
    public class AccountRepository : SqlServer.AccountRepository
    {
        public AccountRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}