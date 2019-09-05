using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetMvc5UsingAutofac.Startup))]
namespace AspNetMvc5UsingAutofac
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
