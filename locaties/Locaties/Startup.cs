using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Locaties.Startup))]
namespace Locaties
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
