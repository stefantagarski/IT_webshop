using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mio_Coffee_WebShop.Startup))]
namespace Mio_Coffee_WebShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
