using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewApi.Services;

namespace NewApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ITestServiceSingleton _testServiceSingleton;
    private readonly ITestServiceTransient _testServiceTransient;
    private readonly ITestServiceScoped _testServiceScoped;
    private BankSettings BankSettings;

    public StudentController(ITestServiceSingleton testServiceSingleton,
        ITestServiceTransient testServiceTransient,
        ITestServiceScoped testServiceScoped,
        IOptions<BankSettings> bankOptions
        )
    {
        _testServiceSingleton = testServiceSingleton;
        _testServiceTransient = testServiceTransient;
        _testServiceScoped = testServiceScoped;
        BankSettings = bankOptions.Value;
    }

    [HttpGet]
    public string Get()
    {
        var t = BankSettings.Username;

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
