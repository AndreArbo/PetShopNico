using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_no1.Startup))]
namespace Project_no1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
