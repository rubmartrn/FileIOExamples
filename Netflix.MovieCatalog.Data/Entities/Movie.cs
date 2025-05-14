namespace Netflix.MovieCatalog.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public int Amount { get; set; }

        public decimal Price { get; set; }
    }
}
