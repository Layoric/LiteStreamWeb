using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using LiteStreamWeb.ServiceInterface;
using LiteStreamWeb.ServiceModel;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace LiteStreamWeb.Tests;

public class UnitTest
{
    private readonly ServiceStackHost appHost;

    public UnitTest()
    {
        appHost = new BasicAppHost().Init();
        appHost.Container.AddTransient<MyServices>();
        appHost.Container.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
            ":memory:",
            SqliteDialect.Provider));
        using var db = appHost.Container.Resolve<IDbConnectionFactory>().OpenDbConnection();
        db.CreateTableIfNotExists<MyTable>();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => appHost.Dispose();

    [Test]
    public void Can_call_MyServices()
    {
        var service = appHost.Container.Resolve<MyServices>();

        var response = (HelloResponse)service.Any(new Hello { Name = "World" });

        Assert.That(response.Result, Is.EqualTo("Hello, World!"));
    }
}