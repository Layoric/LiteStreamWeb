using ServiceStack;

[assembly: HostingStartup(typeof(LiteStreamWeb.ConfigureAutoQuery))]

namespace LiteStreamWeb
{
    public class ConfigureAutoQuery : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureAppHost(appHost => {
                appHost.Plugins.Add(new AutoQueryFeature {
                    MaxLimit = 1000
                });
            });
    }
}