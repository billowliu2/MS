﻿using MS.Lib.Data.Abstractions;

namespace MS.Module.Admin.Infrastructure.Repositories.PostgreSQL
{
    public class RolePageRepository : SqlServer.RolePageRepository
    {
        public RolePageRepository(IDbContext context) : base(context)
        {
        }
    }
}