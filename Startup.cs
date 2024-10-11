using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proptech.Startup))]
namespace Proptech
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
