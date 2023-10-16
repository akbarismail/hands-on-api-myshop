using Microsoft.AspNetCore.Mvc;

namespace MyShopApi.Controllers;

[ApiController]
[Route("api/hello")]
public class HelloController
{
    [HttpGet]
    public string SayHello()
    {
        return "Hello World";
    }

    [HttpGet("get-object")]
    public object GetObject()
    {
        return new
        {
            Id = Guid.NewGuid(),
            Name = "Akbar",
            Date = DateTime.Now
        };
    }

    [HttpGet("get-array")]
    public List<object> GetArrayObj()
    {
        return new List<object>
        {
            new
            {
                Id = Guid.NewGuid(),
                Name = "Akbar",
                Date = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Name = "Ismail",
                Date = DateTime.Now
            }
        };
    }

    [HttpGet("{name}")]
    public string GetWithPathVariable(string name)
    {
        return $"Hello {name}";
    }

    [HttpGet("query-param")]
    public string GetWithQueryParam([FromQuery] string name, [FromQuery] bool isActive)
    {
        return $"Hello {name}, you're is: {isActive}";
    }
}