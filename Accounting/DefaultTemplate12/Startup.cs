using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DefaultTemplate12.Startup))]
namespace DefaultTemplate12
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
