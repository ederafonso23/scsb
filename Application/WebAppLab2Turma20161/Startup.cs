using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppLab2Turma20161.Startup))]
namespace WebAppLab2Turma20161
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
