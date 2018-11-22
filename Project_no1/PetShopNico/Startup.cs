using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetShopNico.Startup))]
namespace PetShopNico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
