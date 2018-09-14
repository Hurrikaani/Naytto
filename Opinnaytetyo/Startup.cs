using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Opinnaytetyo.Startup))]
namespace Opinnaytetyo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}