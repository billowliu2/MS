using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MS.Lib.Host.Web;

namespace MS.Module.Admin.WebHost
{
    public class Startup : StartupAbstract
    {
        public Startup(IHostEnvironment env, IConfiguration cfg) : base(env, cfg)
        {
        }
    }
}