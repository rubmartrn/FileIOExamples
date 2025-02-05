using FluentValidation;
using UniversityProgram.Api.Models.LibraryModels.AddModels;

namespace UniversityProgram.Api.Validators.LibraryValidators
{
    public class LibraryAddModelValidator : AbstractValidator<LibraryAddModel>
    {
        public LibraryAddModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MinimumLength(0);
        }
    }
}
