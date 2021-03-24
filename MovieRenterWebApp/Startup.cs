using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRenterWebApp.Startup))]
namespace MovieRenterWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
