using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Biomorph_Web.Startup))]
namespace Biomorph_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
