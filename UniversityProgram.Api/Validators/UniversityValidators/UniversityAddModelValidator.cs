using FluentValidation;
using UniversityProgram.Api.Models.UniversityModels.AddModels;

namespace UniversityProgram.Api.Validators.UniversityValidators
{
    public class UniversityAddModelValidator : AbstractValidator<UniversityAddModel>
    {
        public UniversityAddModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MinimumLength(3);
        }
    }
}
