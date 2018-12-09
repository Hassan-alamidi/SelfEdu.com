using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SelfEduV2.com.Startup))]
namespace SelfEduV2.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
