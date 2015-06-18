using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc.giris.nw.Startup))]
namespace mvc.giris.nw
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
