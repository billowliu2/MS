using System;

namespace MS.Lib.Data.Abstractions.Entities
{
    /// <summary>
    /// 租户
    /// </summary>
    public interface ITenant
    {
        /// <summary>
        /// 租户编号
        /// </summary>
        Guid? TenantId { get; set; }
    }
}