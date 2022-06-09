using System;
using ServiceStack;
using LitestreamNextTest.ServiceModel;

namespace LitestreamNextTest.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
