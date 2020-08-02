﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.Lib.Pdf.Abstractions;
using MS.Lib.Utils.Core.Helpers;
using System.Linq;

namespace MS.Lib.Pdf.Integration
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加Excel功能
        /// </summary>
        /// <param name="services"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static IServiceCollection AddPdf(this IServiceCollection services, IConfiguration cfg)
        {
            var config = new PdfConfig();
            var section = cfg.GetSection("Pdf");
            if (section != null)
            {
                section.Bind(config);
            }

            services.AddSingleton(config);

            var assembly = AssemblyHelper.LoadByNameEndString($".Lib.Pdf.{config.Provider.ToString()}");
            if (assembly == null)
                return services;

            var handlerType = assembly.GetTypes().FirstOrDefault(m => m.Name.EndsWith("PdfHandler"));
            if (handlerType != null)
            {
                services.AddSingleton(typeof(IPdfHandler), handlerType);
            }

            return services;
        }
    }
}