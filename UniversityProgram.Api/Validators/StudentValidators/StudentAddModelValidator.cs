using FluentValidation;
using UniversityProgram.Api.Models.StudentModels.AddModels;

namespace UniversityProgram.Api.Validators.StudentValidators
{
    public class StudentAddModelValidator : AbstractValidator<StudentAddModel>
    {
        public StudentAddModelValidator()
        {
            RuleFor(e => e.Email).NotEmpty().EmailAddress();
            RuleFor(e => e.Name).NotEmpty().MinimumLength(3);
        }
    }
}
