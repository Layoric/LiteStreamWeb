using Funq;
using ServiceStack;
using LitestreamViteTest.ServiceInterface;

[assembly: HostingStartup(typeof(LitestreamViteTest.AppHost))]

namespace LitestreamViteTest;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices((context, services) => {
            // Configure ASP.NET Core IOC Dependencies
            services.ConfigureNonBreakingSameSiteCookies(context.HostingEnvironment);
        });

    public AppHost() : base("LitestreamViteTest", typeof(MyServices).Assembly) {}

    public override void Configure(Container container)
    {
        SetConfig(new HostConfig {
        });

        Plugins.Add(new SpaFeature {
            EnableSpaFallback = true
        });
        Plugins.Add(new CorsFeature(allowOriginWhitelist:new[]{ 
            "http://localhost:5000",
            "http://localhost:3000",
            "https://localhost:5001",
            "https://" + Environment.GetEnvironmentVariable("DEPLOY_CDN")
        }, allowCredentials:true));

        ConfigurePlugin<UiFeature>(feature => {
            feature.Info.BrandIcon.Uri = "/assets/img/logo.svg";
            feature.Info.BrandIcon.Cls = "inline-block w-8 h-8 mr-2";
        });
    }
}
