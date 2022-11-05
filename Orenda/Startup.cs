using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Orenda.Startup))]
namespace Orenda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
