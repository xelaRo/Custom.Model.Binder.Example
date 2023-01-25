using Custom.Model.Binder.Example.ModelBinders;
using Custom.Model.Binder.Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace Custom.Model.Binder.Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [Route("{weatherType}/GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast([FromCustom] WeatherType weatherType)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = weatherType.Id,
                Date = DateTime.Now.AddDays(Random.Shared.Next(DateTime.Now.Day, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = weatherType.TypeName
            })
            .ToArray();
        }
    }
}