using System.Runtime.CompilerServices;
using UniversityProgram.Api.Entities;
using UniversityProgram.Api.Models.AddressModels.AddModels;
using UniversityProgram.Api.Models.AddressModels.ViewModels;

namespace UniversityProgram.Api.Map
{
    public static class AddressMap
    {
        public static AddressModel Map(this Address address)
        {
            return new AddressModel
            {
                Id = address.Id,
                City = address.City,
                Street = address.Street,
                Country = address.Country
            };
        }

        public static Address Map(this AddressAddModel model)
        {
            return new Address
            {
                City = model.City,
                Street = model.Street,
                Country = model.Country
            };
        }



    }
}
