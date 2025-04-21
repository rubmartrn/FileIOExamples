﻿using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet("Open")]
        public IActionResult Open()
        {
            var model = new StudentModel
            {
                Name = "Open Student",
                Id = 4
            };
            return Ok(model);
        }

        [HttpGet("Private")]
        [Authorize(Roles = "student")]
        public IActionResult Private()
        {
            var model = new StudentModel
            {
                Name = "Private Student",
                Id = 400
            };
            return Ok(model);
        }
    }
}
