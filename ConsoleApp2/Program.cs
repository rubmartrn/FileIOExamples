

using Microsoft.Data.SqlClient;

string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ACA11";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();
    var query = "SELECT * FROM Student";
    SqlCommand command = new SqlCommand(query, connection);
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            Console.WriteLine(reader["Name"]);
        }
    }
}