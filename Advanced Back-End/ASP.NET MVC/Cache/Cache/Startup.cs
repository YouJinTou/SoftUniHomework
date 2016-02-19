using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cache.Startup))]
namespace Cache
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
