// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.WriteLine("Hello, World!");


while (true)
{
    Console.ReadLine();

    try
    {
        var cts = new CancellationTokenSource();
        using var client = new HttpClient();
        var response = await client.GetAsync("http://localhost:5260/Laptops", cts.Token);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            List<LaptopUrish> laptops = JsonSerializer.Deserialize<List<LaptopUrish>>(content, options);
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("Error " + response.ReasonPhrase);
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