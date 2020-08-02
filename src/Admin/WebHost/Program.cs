using MS.Lib.Host.Web;

namespace MS.Module.Admin.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new HostBuilder().Run<Startup>(args);
        }
    }
}