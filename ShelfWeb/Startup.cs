using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShelfWeb.Startup))]
namespace ShelfWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
