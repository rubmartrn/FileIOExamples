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
        cts.CancelAfter(10000);

        var response = await client.GetAsync("http://localhost:5260/Laptops", cts.Token);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            List<LaptopUrish> laptops = JsonSerializer.Deserialize<List<LaptopUrish>>(content);
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
    public int id { get; set; }
    public string name { get; set; } = default!;
}