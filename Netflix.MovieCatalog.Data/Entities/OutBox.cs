using Netflix.MovieCatalog.Data.Enums;

namespace Netflix.MovieCatalog.Data.Entities
{
    public class OutBox
    {
        public int Id { get; set; }
        public OutBoxType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Data { get; set; } = default!;
        public bool Done { get; set; }
    }
}
