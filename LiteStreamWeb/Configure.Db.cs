using LiteStreamWeb.ServiceModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

[assembly: HostingStartup(typeof(LiteStreamWeb.ConfigureDb))]

namespace LiteStreamWeb
{
    public class ConfigureDb : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureServices((context, services) => {
                services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
                    context.Configuration.GetConnectionString("DefaultConnection")
                    ?? "App_Data/LiteStreamWeb.sqlite",
                    SqliteDialect.Provider));
            })
            .ConfigureAppHost(afterConfigure:appHost => {
                appHost.ScriptContext.ScriptMethods.Add(new DbScriptsAsync());

                // Create non-existing Table and add Seed Data Example
                // using var db = appHost.Resolve<IDbConnectionFactory>().Open();
                // if (db.CreateTableIfNotExists<MyTable>())
                // {
                //     db.Insert(new MyTable { Name = "Seed Data for new MyTable" });
                // }
            });
    }
}
