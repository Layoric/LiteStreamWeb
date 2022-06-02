using ServiceStack;
using ServiceStack.DataAnnotations;

namespace LiteStreamWeb.ServiceModel;

[Route("/hello")]
[Route("/hello/{Name}")]
public class Hello : IReturn<HelloResponse>
{
    public string Name { get; set; }
}

public class HelloResponse
{
    public string Result { get; set; }
}

// Example Data Model
public class MyTable
{
    [AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
}

public class QueryMyTable : QueryDb<MyTable>
{
    
}
