using FluentValidation;
using UniversityProgram.Api.Models.LaptopModels.AddModels;

namespace UniversityProgram.Api.Validators.LaptopValidators
{
    public class LaptopAddModelValidator : AbstractValidator<LaptopAddModel>
    {
        public LaptopAddModelValidator(StudentDbContext context)
        {
            RuleFor(e => e.Name)
                .NotNull().WithMessage("Նեյմը պետք է նալ չլինի")
                .MinimumLength(3).WithMessage("Մինիմալ երկարությունը պետք է լինի երեք նիշ")
                .MaximumLength(45).WithMessage("մաքսիմալ երկարությունը պետք է լինի 45 նիշ");


            //RuleFor(e => e.Cpu).SetValidator(new CpuAddModelValidator());
        }
    }
}