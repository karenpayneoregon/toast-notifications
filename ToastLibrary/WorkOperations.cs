using System.Text.Json;
using ToastLibrary.Models;
using Log = Serilog.Log;

namespace ToastLibrary;
public class WorkOperations
{
    public static void Snooze()
    {
        Log.Information("Snooze at {D1}", DateTime.Now.ToString("h:mm:ss tt"));
    }

    public static void GotoWork()
    {
        Log.Information("Go to work at {D1}", DateTime.Now.ToString("h:mm:ss tt"));
    }

    public static async Task<List<PublicHoliday>> GetHolidays(string countryCode = "US")
    {
    
        var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(
            $"https://date.nager.at/api/v3/publicholidays/{DateTime.Now.Year}/{countryCode}");

        if (response.IsSuccessStatusCode)
        {
            await using Stream jsonStream = await response.Content.ReadAsStreamAsync();

            // Distinct is used as there were duplicate entries
            return JsonSerializer.Deserialize<PublicHoliday[]>(jsonStream, jsonSerializerOptions)
                    !.Distinct(PublicHoliday.DateComparer).ToList();
        }
        else
        {
            return Enumerable.Empty<PublicHoliday>().ToList();
        }
    }
}
