using Desfran.Services.Interfaces;
using Newtonsoft.Json;
using static Desfran.Models.Weather;

namespace Desfran.Services.Repositories
{
    public class WeatherRepository : IWeatherInterface
    {
        public async Task<IEnumerable<Next_Days>> GetNextDays()
        {
            var _ = new Root();

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://weatherdbi.herokuapp.com/data/weather/41.601418,-87.617012");

            string? apiResponse = await response.Content.ReadAsStringAsync();

            _ = JsonConvert.DeserializeObject<Root>(apiResponse);

            List<Next_Days> nextDays = _!.Next_days!.ToList();

            return nextDays;
        }
    }
}
