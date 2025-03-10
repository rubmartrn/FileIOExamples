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
        client.BaseAddress = new Uri("http://localhost:5260/");
        var response1 = await client.GetAsync("Students/1", cts.Token);
        var response2 = await client.GetAsync("Students/Query?id=1&name=sjkhfsd", cts.Token);


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