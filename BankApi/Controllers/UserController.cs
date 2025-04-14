﻿using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        [HttpGet("login")]
        public IActionResult Login([FromQuery] string token)
        {
            HttpContext.Response.Cookies.Append("token", token);
            return Redirect("/swagger/index.html");
        }
    }
}
