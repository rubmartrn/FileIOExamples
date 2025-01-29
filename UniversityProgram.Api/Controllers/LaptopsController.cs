using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopsController : ControllerBase
    {
        private readonly StudentDbContext _ctx;

        public LaptopsController(StudentDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var laptops = await _ctx.Laptops.ToListAsync();
            return Ok(laptops);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LaptopAddModel model)
        {
            var laptop = new Laptop
            {
                Name = model.Name,
                StudentId = model.StudentId ?? 0
            };
            _ctx.Laptops.Add(laptop);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}