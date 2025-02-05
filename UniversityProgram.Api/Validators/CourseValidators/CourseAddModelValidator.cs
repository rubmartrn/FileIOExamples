using FluentValidation;
using UniversityProgram.Api.Models.CourseModels.AddModels;

namespace UniversityProgram.Api.Validators.CourseValidators
{
    public class CourseAddModelValidator : AbstractValidator<CourseAddModel>
    {
        public CourseAddModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(100);
            RuleFor(e => e.Fee).NotEmpty().GreaterThan(0);
        }
    }
}
