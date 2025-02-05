using UniversityProgram.Api.Models.AddressModels.ViewModels;

namespace UniversityProgram.Api.Models.StudentModels.ViewModels
{
    public class StudentWithAddressModel : StudentModel
    {
        public AddressModel? AddressModel { get; set; } = default!;
    }
}
