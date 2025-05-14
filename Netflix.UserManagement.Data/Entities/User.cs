namespace Netflix.UserManagement.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;

        public decimal Money { get; set; }
    }
}
