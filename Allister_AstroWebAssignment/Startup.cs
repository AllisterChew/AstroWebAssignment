using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Allister_AstroWebAssignment.Startup))]
namespace Allister_AstroWebAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
