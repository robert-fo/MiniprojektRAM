using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniprojektRAM.Startup))]
namespace MiniprojektRAM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
