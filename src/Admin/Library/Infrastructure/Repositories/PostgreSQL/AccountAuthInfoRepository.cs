using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.PostgreSQL
{
    public class AccountAuthInfoRepository : SqlServer.AccountAuthInfoRepository
    {
        public AccountAuthInfoRepository(IDbContext context) : base(context)
        {
        }
    }
}