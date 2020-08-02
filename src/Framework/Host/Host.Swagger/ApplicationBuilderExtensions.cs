using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MS.Lib.Host.Swagger.Extensions;
using MS.Lib.Module.Abstractions;
using MS.Lib.Module.AspNetCore;

namespace MS.Lib.Host.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 自定义Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            var modules = app.ApplicationServices.GetService<IModuleCollection>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                if (modules == null) return;

                foreach (var module in modules)
                {
                    if (((ModuleDescriptor)module).Initializer == null)
                        continue;

                    foreach (var g in module.GetGroups())
                    {
                        c.SwaggerEndpoint($"/swagger/{g.Key}/swagger.json", g.Value);
                    }
                }
            });

            return app;
        }
    }
}