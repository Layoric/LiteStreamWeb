using Funq;
using ServiceStack;
using LiteStreamWeb.ServiceInterface;

[assembly: HostingStartup(typeof(LiteStreamWeb.AppHost))]

namespace LiteStreamWeb;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public AppHost() : base("LiteStreamWeb", typeof(MyServices).Assembly) {}

    public override void Configure(Container container)
    {
        // Configure ServiceStack only IOC, Config & Plugins
        SetConfig(new HostConfig {
            UseSameSiteCookies = true,
        });
    }
}
