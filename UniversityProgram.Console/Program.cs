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
        var responseTask = client.GetAsync("http://localhost:5260/Laptops", cts.Token);
        Console.WriteLine("Press esc to cancel");

        if (Console.ReadKey().Key == ConsoleKey.Escape)
        {
            cts.Cancel();
        }

        var response = await responseTask;
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