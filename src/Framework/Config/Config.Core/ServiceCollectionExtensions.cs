using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MS.Lib.Config.Abstractions;

namespace MS.Lib.Config.Core
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加配置管理
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddConfig(this IServiceCollection services)
        {
            //配置核心服务
            services.AddConfigCore();
            //添加内存配置存储实现
            services.TryAddScoped<IConfigStorageProvider, MemoryConfigStorageProvider>();
            //配置实例提供器
            services.TryAddSingleton<IConfigProvider, ConfigProvider>();

            return services;
        }
    }
}