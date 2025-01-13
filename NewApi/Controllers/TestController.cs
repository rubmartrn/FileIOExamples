using Microsoft.AspNetCore.Mvc;
using NewApi.Services;

namespace NewApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{

    [HttpGet("Content")]
    public ContentResult GetContent()
    {
        return new ContentResult
        {
            Content = "Hello World",
            StatusCode = 200
        };
    }

    [HttpGet("Json")]
    public JsonResult GetJson()
    {
        return new JsonResult(new
        {
            Name = "Petros",
            Age = 25,
            suihsdiufsdf = "sdfsd"
        });
    }

    [HttpGet("Redirect")]
    public RedirectResult GetRedirect()
    {
        return new RedirectResult("https://www.google.com");
    }
}
