using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public object HelloWorld()
    {
        return "Hello World";
    }
}