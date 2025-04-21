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
            var rand = new Random().Next(10);
            if (rand % 2 == 0)
            {
               throw new Exception("Random exception");
            }
            var model = new StudentModel
            {
                Name = "Open Student",
                Id = 4
            };
            return Ok(model);
        }

        [HttpGet("Private")]
        [Authorize]
        public IActionResult Private()
        {
            var model = new StudentModel
            {
                Name = "Private Student",
                Id = 400
            };
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            var model = new StudentModel
            {
                Name = "Student",
                Id = id
            };
            return Ok(model);
        }

        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            var model = new StudentModel
            {
                Name = "Student",
                Id = id
            };
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Add([FromBody] StudentModel model, CancellationToken tk)
        {
            return Ok(model);
        }
    }
}
