using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DIUB.Startup))]
namespace DIUB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
