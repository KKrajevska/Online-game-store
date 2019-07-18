using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_game_store.Startup))]
namespace Online_game_store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
