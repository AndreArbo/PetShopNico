using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetsShop.Startup))]
namespace PetsShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
