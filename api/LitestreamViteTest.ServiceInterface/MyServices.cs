using System;
using ServiceStack;
using LitestreamViteTest.ServiceModel;

namespace LitestreamViteTest.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!!!!11one" };
        }
    }
}
