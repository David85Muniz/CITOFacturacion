using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CITOFacturacion.Startup))]
namespace CITOFacturacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
