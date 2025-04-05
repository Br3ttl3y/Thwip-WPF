using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Thwip_WPF.Client;

public class SpiderManClient
{
    // Constructor
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "http://localhost:3000/spiderman/"; 

    public SpiderManClient()
    {
        _httpClient = new HttpClient();
    }

    // Example method stub
    public async Task<object?> GetSpiderManData()
    {
        try{
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            dynamic? data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            // Replace with actual data processing logic
            return data;
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            
        }

        return null;
    }

}