﻿using MS.Lib.Config.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace MS.Module.Admin.Application.ConfigService.ViewModels
{
    public class ConfigUpdateModel
    {
        [Required(ErrorMessage = "配置类编码不能为空")]
        public string Code { get; set; }

        public ConfigType Type { get; set; }

        [Required(ErrorMessage = "配置内容不能为空")]
        public string Json { get; set; }
    }
}