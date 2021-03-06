﻿using MS.Lib.Auth.Abstractions;
using MS.Lib.Auth.Abstractions.LoginModels;
using MS.Lib.Data.Query;
using System;

namespace MS.Module.Admin.Domain.LoginLog.Models
{
    /// <summary>
    /// 登录日志查询模型
    /// </summary>
    public class LoginLogQueryModel : QueryModel
    {
        /// <summary>
        /// 账户编号
        /// </summary>
        public Guid? AccountId { get; set; }

        /// <summary>
        /// 登录平台
        /// </summary>
        public Platform? Platform { get; set; }

        /// <summary>
        /// 登录方式
        /// </summary>
        public LoginMode? LoginMode { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}