using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Api.Models.AddressModels.AddModels;
using UniversityProgram.Api.Models.AddressModels.UpdateModels;
using UniversityProgram.Api.Services.AddressService.Abstract;

namespace UniversityProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok(await _addressService.GetAllAsync(token));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken token)
        {
            return Ok(await _addressService.GetByIdAsync(id, token));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddressAddModel model, [FromServices] IValidator<AddressAddModel> validator, CancellationToken token)
        {
            await _addressService.AddAsync(model, validator, token);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            await _addressService.DeleteAsync(id, token);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AddressUpdateModel model, CancellationToken token)
        {
            await _addressService.UpdateAsync(id, model, token);
            return NoContent();
        }
    }

}
