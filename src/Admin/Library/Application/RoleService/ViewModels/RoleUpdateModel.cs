﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MS.Module.Admin.Application.RoleService.ViewModels
{
    public class RoleUpdateModel : RoleAddModel
    {
        [Required(ErrorMessage = "请选择角色")]
        public Guid Id { get; set; }
    }
}