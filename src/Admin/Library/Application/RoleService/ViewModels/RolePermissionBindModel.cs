using MS.Lib.Auth.Abstractions;
using MS.Lib.Utils.Core.Validations;
using System;
using System.Collections.Generic;

namespace MS.Module.Admin.Application.RoleService.ViewModels
{
    public class RolePermissionBindModel
    {
        [NotEmpty(ErrorMessage = "请选择角色")]
        public Guid RoleId { get; set; }

        public Platform Platform { get; set; }

        public List<string> Permissions { get; set; }
    }
}