using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Core;
using MS.Module.Admin.Domain.AccountConfig;
using System;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class AccountConfigRepository : RepositoryAbstract<AccountConfigEntity>, IAccountConfigRepository
    {
        public AccountConfigRepository(IDbContext context) : base(context)
        {
        }

        public Task<AccountConfigEntity> GetByAccount(Guid accountId)
        {
            return GetAsync(m => m.AccountId == accountId);
        }
    }
}