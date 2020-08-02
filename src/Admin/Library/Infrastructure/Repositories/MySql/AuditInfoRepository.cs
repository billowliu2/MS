using MS.Lib.Data.Abstractions;
using MS.Lib.Utils.Core.Result;
using MS.Module.Admin.Infrastructure.Repositories.MySql.Sql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.MySql
{
    public class AuditInfoRepository : SqlServer.AuditInfoRepository
    {
        public AuditInfoRepository(IDbContext context) : base(context)
        {
        }

        public override Task<IEnumerable<ChartDataResultModel>> QueryLatestWeekPv()
        {
            var sql = string.Format(AuditInfoSql.QueryLatestWeekPv, Db.EntityDescriptor.TableName);
            return Db.QueryAsync<ChartDataResultModel>(sql);
        }
    }
}