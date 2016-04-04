using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeaCargo.Startup))]
namespace SeaCargo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
