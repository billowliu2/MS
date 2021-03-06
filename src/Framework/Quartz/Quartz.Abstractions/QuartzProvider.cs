﻿using System.ComponentModel;

namespace MS.Lib.Quartz.Abstractions
{
    public enum QuartzProvider
    {
        [Description("SqlServer")]
        SqlServer,

        [Description("MySql")]
        MySql,

        [Description("SQLite-Microsoft")]
        SQLite,

        [Description("OracleODP")]
        Oracle,

        [Description("Npgsql")]
        PostgreSQL
    }
}