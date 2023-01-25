using Custom.Model.Binder.Example.Models;

namespace Custom.Model.Binder.Example.Data
{
    public class WeatherData : IWeatherDataProvider
    {
        private static readonly WeatherType[] weatherTypes = new[]
        {
            new WeatherType()
            {
                Id = 1,
                TypeName = "Freezing"
            },
            new WeatherType()
            {
                Id = 2,
                TypeName = "Bracing",
            },
            new WeatherType()
            {
                Id = 3,
                TypeName = "Chilly",
            },
            new WeatherType()
            {
                Id = 4,
                TypeName = "Cool",
            },
            new WeatherType()
            {
                Id = 5,
                TypeName = "Mild",
            },
            new WeatherType()
            {
                Id = 6,
                TypeName = "Warm",
            },
            new WeatherType()
            {
                Id = 7,
                TypeName = "Balmy",
            },
            new WeatherType()
            {
                Id = 8,
                TypeName = "Hot",
            },
            new WeatherType()
            {
                Id = 9,
                TypeName = "Sweltering",
            },
            new WeatherType()
            {
                Id = 10,
                TypeName = "Scorching",
            },

        };

        public IEnumerable<WeatherType> GetWeatherTypes()
        {
            return weatherTypes;
        }

        public WeatherType GetWeatherType(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            return weatherTypes.FirstOrDefault(w => w.TypeName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
