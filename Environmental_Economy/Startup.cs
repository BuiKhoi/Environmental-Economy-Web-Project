using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Environmental_Economy.Startup))]
namespace Environmental_Economy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
