using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Map;
using UniversityProgram.Api.Models.AddressModels.AddModels;
using UniversityProgram.Api.Models.AddressModels.UpdateModels;
using UniversityProgram.Api.Models.AddressModels.ViewModels;
using UniversityProgram.Api.Services.AddressService.Abstract;
using UniversityProgram.Api.Validators.ObjectValidator;

namespace UniversityProgram.Api.Services.AddressService.Impl
{
    public class AddressService : IAddressService
    {

        private readonly StudentDbContext _dbContext;

        public AddressService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(AddressAddModel model, IValidator<AddressAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            await _dbContext.Addresses.AddAsync(model.Map()!, token);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(address);
            _dbContext.Addresses.Remove(address!);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<IEnumerable<AddressModel>> GetAllAsync(CancellationToken token)
        {
            var addresses = await _dbContext.Addresses.ToListAsync(token);
            return addresses.Select(e => e.Map());
        }

        public async Task<AddressModel> GetByIdAsync(int id, CancellationToken token)
        {
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(address);
            return address!.Map();
        }

        public async Task UpdateAsync(int id, AddressUpdateModel model, CancellationToken token)
        {
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(e => e.Id == id, token);
            ObjectValidator.ThrowIfNull(address);

            address!.Street = model.Street ?? address.Street;
            address.City = model.City ?? address.City;
            address.Country = model.Country ?? address.Country;

            await _dbContext.SaveChangesAsync(token);
        }
    }
}
