using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DebugAthletics.Startup))]
namespace DebugAthletics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
