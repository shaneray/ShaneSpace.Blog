using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShanesSpot.Startup))]
namespace ShanesSpot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
