using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gradebook.WebMVC.Startup))]
namespace Gradebook.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
