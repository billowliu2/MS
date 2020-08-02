using MS.Lib.Data.Abstractions;
using MS.Lib.Utils.Core.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Infrastructure.Repositories.PostgreSQL
{
    public class AuditInfoRepository : SqlServer.AuditInfoRepository
    {
        public AuditInfoRepository(IDbContext context) : base(context)
        {
        }

        public override Task<IEnumerable<ChartDataResultModel>> QueryLatestWeekPv()
        {
            throw new NotImplementedException();

            //var sql = string.Format(AuditInfoSql.QueryLatestWeekPv, Db.EntityDescriptor.TableName);
            //return Db.QueryAsync<ChatDataRow>(sql);
        }
    }
}