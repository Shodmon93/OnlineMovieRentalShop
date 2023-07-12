using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyWithData.Startup))]
namespace VidlyWithData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
