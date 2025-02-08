//using FluentValidation;
//using Microsoft.EntityFrameworkCore;
//using UniversityProgram.Api.Models;

//namespace UniversityProgram.Api.Validators
//{
//    public class LaptopAddModelValidator : AbstractValidator<LaptopAddModel>
//    {
//        public LaptopAddModelValidator(StudentDbContext context)
//        {
//            RuleFor(e => e.Name)
//                .NotNull().WithMessage("Նեյմը պետք է նալ չլինի")
//                .MinimumLength(3).WithMessage("Մինիմալ երկարությունը պետք է լինի երեք նիշ")
//                .MaximumLength(45).WithMessage("մաքսիմալ երկարությունը պետք է լինի 45 նիշ");

//            RuleFor(e => e.StudentId)
//                .GreaterThanOrEqualTo(0).WithMessage("Ընտրեք ուսանողի Id-ն")
//                .MustAsync(async (e, token) => await context.Students.AnyAsync(s => s.Id == e)).WithMessage("Տվյալ այդիով ուսանող չկա");

//            //RuleFor(e => e.Cpu).SetValidator(new CpuAddModelValidator());
//        }
//    }

//    public class CpuAddModelValidator : AbstractValidator<CpuAddModel>
//    {
//        public CpuAddModelValidator()
//        {
//            RuleFor(e => e.Name).NotNull().Must(e =>
//            {
//                foreach (var a in e)
//                {
//                    if (char.IsSymbol(a))
//                    {
//                        return false;
//                    }
//                }
//                return true;
//            }).WithMessage("Սիմվոլներ չեն կարելի");

//            RuleFor(e => e.Id).Must(e => e > 5).WithMessage("Id-ն պետք է զրոյից մեծ լինի");
//        }
//    }
//}