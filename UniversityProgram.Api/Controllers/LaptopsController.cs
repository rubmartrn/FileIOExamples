using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.BLL.Models;
using UniversityProgram.Data;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopsController : ControllerBase
    {
        private readonly StudentDbContext _ctx;
        private readonly IMapper _mapper;

        public LaptopsController(StudentDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Laptop> laptops = await _ctx.Laptops.ToListAsync();
            List<LaptopModel> models = _mapper.Map<List<LaptopModel>>(laptops);
            return Ok(models);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LaptopAddModel model,
             [FromServices] IValidator<LaptopAddModel> validator,
            CancellationToken token)
        {
            var result = await validator.ValidateAsync(model, token);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var laptop = _mapper.Map<Laptop>(model);

            _ctx.Laptops.Add(laptop);
            await _ctx.SaveChangesAsync(token);
            return Ok();
        }

        [HttpGet("cpuName")]
        public async Task<IActionResult> GetCpuName()
        {
            var laptops = await _ctx.Laptops
                .Include(e => e.Cpu)
                .ToListAsync();

            var laptopQuery = _ctx.Laptops
                .Include(e => e.Cpu)
                .ProjectTo<LaptopWithCpuName>(_mapper.ConfigurationProvider)
                .ToQueryString();

            var result = _mapper.Map<List<LaptopWithCpuName>>(laptops);
            return Ok(result);
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