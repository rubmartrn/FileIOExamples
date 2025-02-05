using FluentValidation;
using UniversityProgram.Api.Models.CpuModels.AddModels;

namespace UniversityProgram.Api.Validators.CpuValidators
{
    public class CpuAddModelValidator : AbstractValidator<CpuAddModel>
    {
        public CpuAddModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MinimumLength(3);
        }
    }
}
