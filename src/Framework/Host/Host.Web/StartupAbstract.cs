using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.Lib.Host.Web.Options;

namespace MS.Lib.Host.Web
{
    public abstract class StartupAbstract
    {
        protected readonly IHostEnvironment Env;
        private readonly IConfiguration _cfg;
        private readonly WebHostOptions _hostOptions;

        protected StartupAbstract(IHostEnvironment env, IConfiguration cfg)
        {
            Env = env;
            _cfg = cfg;

            //主机配置
            _hostOptions = new WebHostOptions();
            cfg.GetSection("Host").Bind(_hostOptions);

            if (_hostOptions.Urls.IsNull())
                _hostOptions.Urls = "http://*:5000";
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddWebHost(_hostOptions, Env, _cfg);
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseWebHost(_hostOptions, Env);

            app.UseShutdownHandler();
        }
    }
}