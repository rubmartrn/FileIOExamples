using Microsoft.AspNetCore.Mvc;
using NewApi.Services;

namespace NewApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ITestServiceSingleton _testServiceSingleton;
    private readonly ITestServiceTransient _testServiceTransient;
    private readonly ITestServiceScoped _testServiceScoped;

    public TestController(ITestServiceSingleton testServiceSingleton,
        ITestServiceTransient testServiceTransient,
        ITestServiceScoped testServiceScoped)
    {
        _testServiceSingleton = testServiceSingleton;
        _testServiceTransient = testServiceTransient;
        _testServiceScoped = testServiceScoped;
    }

    [HttpGet]
    public string Get()
    {
        var a = _testServiceSingleton.Test();
        var b = _testServiceTransient.Test();
        var c = _testServiceScoped.Test();

        return "Petros";
    }

    [HttpPost]
    public string Post()
    {
        return "Post Petros";
    }
}
