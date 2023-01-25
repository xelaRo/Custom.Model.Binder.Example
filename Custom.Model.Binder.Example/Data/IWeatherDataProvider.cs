using Custom.Model.Binder.Example.Models;

namespace Custom.Model.Binder.Example.Data
{
    public interface IWeatherDataProvider
    {
        IEnumerable<WeatherType> GetWeatherTypes();
        WeatherType GetWeatherType(string name);
    }
}