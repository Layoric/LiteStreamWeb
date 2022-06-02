using ServiceStack;
using LiteStreamWeb.ServiceModel;
using ServiceStack.OrmLite;

namespace LiteStreamWeb.ServiceInterface;

public class MyServices : Service
{
    public object Any(Hello request)
    {
        Db.Insert(new MyTable
        {
            Name = request.Name
        });
        return new HelloResponse { Result = $"Hello, {request.Name}!" };
    }
}