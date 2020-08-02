using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.PostgreSQL
{
    public class LoginLogRepository : SqlServer.LoginLogRepository
    {
        public LoginLogRepository(IDbContext context) : base(context)
        {
        }
    }
}