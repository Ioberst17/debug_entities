using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AthleticDebug.Startup))]
namespace AthleticDebug
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
