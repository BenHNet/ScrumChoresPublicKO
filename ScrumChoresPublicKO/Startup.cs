using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScrumChoresPublicKO.Startup))]
namespace ScrumChoresPublicKO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
