// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");
Console.OutputEncoding = Encoding.UTF8; 

while (true)
{
    Console.ReadLine();

    try
    {
        var cts = new CancellationTokenSource();
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5260/");
        var request = new HttpRequestMessage(HttpMethod.Post, "/Students");

        Console.WriteLine("Գրեք ուսանողի անունը");
        string name = Console.ReadLine();

        Console.WriteLine("Գրեք ուսանողի մեյլը");
        string email = Console.ReadLine();

        var model = new Model()
        {
            Name = name,
            Email = email
        };

        var json = JsonSerializer.Serialize(model);

        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response1 = await client.SendAsync(request, cts.Token);


        if (response1.IsSuccessStatusCode)
        {
            var content = await response1.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            //List<LaptopUrish> laptops = JsonSerializer.Deserialize<List<LaptopUrish>>(content, options);
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("Error " + response1.ReasonPhrase);
        }

        Console.WriteLine();
    }
    catch (Exception)
    {

        throw;
    }
}

public class LaptopUrish
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}

public class Model
{
    public string? Name { get; set; } = default!;

    public string? Email { get; set; } = default!;
}