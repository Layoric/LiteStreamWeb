using System;
using ServiceStack;
using LitestreamVueTest.ServiceModel;

namespace LitestreamVueTest.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
