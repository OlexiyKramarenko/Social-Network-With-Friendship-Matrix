using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FriendshipMatrix.Startup))]
namespace FriendshipMatrix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        { 
            ConfigureAuth(app);
        }
    }
}
