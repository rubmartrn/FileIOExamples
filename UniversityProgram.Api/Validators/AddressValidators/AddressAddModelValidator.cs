using FluentValidation;
using UniversityProgram.Api.Models.AddressModels.AddModels;

namespace UniversityProgram.Api.Validators.AddressValidators
{
    public class AddressAddModelValidator : AbstractValidator<AddressAddModel>
    {
        public AddressAddModelValidator()
        {
            RuleFor(e => e.Street).NotEmpty();
            RuleFor(e => e.City).NotEmpty();
            RuleFor(e => e.Country).NotEmpty();
        }
    }
}
