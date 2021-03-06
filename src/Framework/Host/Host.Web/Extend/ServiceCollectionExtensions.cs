﻿using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.Lib.Auth.Jwt;
using MS.Lib.Cache.Integration;
using MS.Lib.Config.Core;
using MS.Lib.Data.Integration;
using MS.Lib.Excel.Integration;
using MS.Lib.Host.Swagger;
using MS.Lib.Host.Swagger.Conventions;
using MS.Lib.Host.Web.Options;
using MS.Lib.Mapper.AutoMapper;
using MS.Lib.Module.AspNetCore;
using MS.Lib.OSS.Integration;
using MS.Lib.Utils.Core;
using MS.Lib.Validation.FluentValidation;
using System;

namespace MS.Lib.Host.Web
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加WebHost
        /// </summary>
        /// <param name="services"></param>
        /// <param name="webhostOptions"></param>
        /// <param name="env">环境</param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebHost(this IServiceCollection services, WebHostOptions webhostOptions, IHostEnvironment env, IConfiguration cfg)
        {
            services.AddSingleton(webhostOptions);

            services.AddMSServices();

            //加载缓存
            services.AddCache(cfg);

            //加载模块
            var modules = services.AddModules();

            //添加对象映射
            services.AddMappers(modules);

            //主动或者开发模式下开启Swagger
            if (webhostOptions.Swagger || env.IsDevelopment())
            {
                services.AddSwagger(modules);
            }

            //添加MVC功能
            services.AddMvc(c =>
            {
                if (webhostOptions.Swagger || env.IsDevelopment())
                {
                    //API分组约定
                    c.Conventions.Add(new ApiExplorerGroupConvention());
                }

                //模块中的MVC配置
                foreach (var module in modules)
                {
                    ((ModuleDescriptor)module).Initializer?.ConfigureMvc(c);
                }
            })
            .AddNewtonsoftJson(options =>
            {
                //设置日期格式化格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            })
            .AddValidators(services)//添加验证器
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //CORS
            services.AddCors(options =>
            {
                /*浏览器的同源策略，就是出于安全考虑，浏览器会限制从脚本发起的跨域HTTP请求（比如异步请求GET, POST, PUT, DELETE, OPTIONS等等，
                        所以浏览器会向所请求的服务器发起两次请求，第一次是浏览器使用OPTIONS方法发起一个预检请求，第二次才是真正的异步请求，
                        第一次的预检请求获知服务器是否允许该跨域请求：如果允许，才发起第二次真实的请求；如果不允许，则拦截第二次请求。
                        Access-Control-Max-Age用来指定本次预检请求的有效期，单位为秒，，在此期间不用发出另一条预检请求。*/
                var preflightMaxAge = webhostOptions.PreflightMaxAge < 0 ? new TimeSpan(0, 30, 0) : new TimeSpan(0, 0, webhostOptions.PreflightMaxAge);

                options.AddPolicy("Default",
                    builder => builder.AllowAnyOrigin()
                        .SetPreflightMaxAge(preflightMaxAge)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition"));//下载文件时，文件名称会保存在headers的Content-Disposition属性里面
            });

            //添加数据库，数据库依赖ILoginInfo，所以需要在添加身份认证以及MVC后添加数据库
            services.AddDb(cfg, modules);

            //解决Multipart body length limit 134217728 exceeded
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
            });

            //添加HttpClient相关
            services.AddHttpClient();

            //添加模块的自定义服务
            services.AddModuleServices(modules, env, cfg);

            //添加配置管理
            services.AddConfig();

            //Jwt身份认证(需要从配置中读取jwt相关配置，所以要放在配置管理后面)
            services.AddJwtAuth();

            //添加模块初始化服务
            services.AddModuleInitializerServices(modules, env, cfg);

            //添加Excel相关功能
            services.AddExcel(cfg);

            //添加OSS相关功能
            services.AddOSS(cfg);

            return services;
        }
    }
}