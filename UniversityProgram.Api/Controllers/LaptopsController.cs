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
        public async Task<IActionResult> Add([FromBody] LaptopAddModel model,
            // [FromServices] IValidator<LaptopAddModel> validator,
            CancellationToken token)
        {

            //var result = await validator.ValidateAsync(model, token);
            //if (!result.IsValid)
            //{
            //    return BadRequest(result.Errors);
            //}
            var laptop = new Laptop
            {
                Name = model.Name,
                StudentId = model.StudentId ?? 0
            };
            _ctx.Laptops.Add(laptop);
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }

        [HttpGet("{id}/cpu")]
        public async Task<IActionResult> GetCpu([FromRoute] int id)
        {
            var laptop = await _ctx.Laptops
                .FirstOrDefaultAsync(e => e.Id == id);

            await _ctx.Entry(laptop).Reference(e => e.Cpu).LoadAsync();

            if (laptop == null)
            {
                return NotFound();
            }

            var model = new LaptopWithCpuModel()
            {
                Id = laptop.Id,
                Name = laptop.Name,
                Cpu = laptop.Cpu is null
                    ? null
                    : new CpuModel()
                    {
                        Id = laptop.Cpu.Id,
                        Name = laptop.Cpu.Name
                    }
            };

            return Ok(model);
        }

        [HttpPut("{id}/cpu")]
        public async Task<IActionResult> AddCpu([FromRoute] int id, [FromBody] CpuAddModel model)
        {
            var laptop = await _ctx.Laptops.FirstOrDefaultAsync(e => e.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }
            var cpu = new Cpu
            {
                Name = model.Name,
                LaptopId = laptop.Id
            };

            laptop.Cpu = cpu;
            _ctx.Update(laptop);
            await _ctx.SaveChangesAsync();

            return Ok();
        }
    }
}