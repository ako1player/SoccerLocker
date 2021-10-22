using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoccerLocker.Startup))]
namespace SoccerLocker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
