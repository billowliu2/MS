using MS.Lib.Data.Abstractions;
using MS.Lib.Utils.Core.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.SQLite
{
    public class AuditInfoRepository : SqlServer.AuditInfoRepository
    {
        public AuditInfoRepository(IDbContext context) : base(context)
        {
        }

        public override Task<IEnumerable<ChartDataResultModel>> QueryLatestWeekPv()
        {
            var sql = @"SELECT
	strftime('%Y-%m-%d',ExecutionTime) `Key`,
	COUNT(0) `Value`
FROM
	AuditInfo
WHERE
	ExecutionTime > date('now','+7 day')
GROUP BY
	[Key] ORDER BY [Key]
	";

            return Db.QueryAsync<ChartDataResultModel>(sql);
        }
    }
}