﻿using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.PostgreSQL
{
    public class MimeRepository : SqlServer.MimeRepository
    {
        public MimeRepository(IDbContext context) : base(context)
        {
        }
    }
}