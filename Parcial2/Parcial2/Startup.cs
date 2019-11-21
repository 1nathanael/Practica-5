using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parcial2.Startup))]
namespace Parcial2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
