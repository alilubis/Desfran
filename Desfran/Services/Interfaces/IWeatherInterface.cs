using static Desfran.Models.Weather;

namespace Desfran.Services.Interfaces
{
    public interface IWeatherInterface
    {
        Task<IEnumerable<Next_Days>> GetNextDays();
    }
}
