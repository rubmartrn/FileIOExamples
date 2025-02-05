namespace UniversityProgram.Api.Models.AddressModels.ViewModels
{
    public class AddressModel
    {
        public int Id { get; set; }

        public string Country { get; set; } = default!;

        public string City { get; set; } = default!;

        public string Street { get; set; } = default!;
    }
}
