namespace BackGroundApi.Data
{
    public static class Database
    {
        public static List<Report> Reports { get; set; } = [];

    }

    public class Report
    {
        public string Name { get; set; }
        public string Information { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
