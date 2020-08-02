using MS.Lib.Auth.Abstractions;
using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Module.Admin.Domain.AccountAuthInfo;
using System;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class AccountAuthInfoRepository : RepositoryAbstract<AccountAuthInfoEntity>, IAccountAuthInfoRepository
    {
        public AccountAuthInfoRepository(IDbContext context) : base(context)
        {
        }

        public Task<AccountAuthInfoEntity> Get(Guid accountId, Platform platform)
        {
            return Db.Find(m => m.AccountId == accountId && m.Platform == platform).FirstAsync();
        }

        public Task<AccountAuthInfoEntity> GetByRefreshToken(string refreshToken)
        {
            return Db.Find(m => m.RefreshToken == refreshToken).FirstAsync();
        }
    }
}