using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmBayMVC.Startup))]
namespace FilmBayMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
