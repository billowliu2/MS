using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.MySql
{
    public class LoginLogRepository : SqlServer.LoginLogRepository
    {
        public LoginLogRepository(IDbContext context) : base(context)
        {
        }
    }
}