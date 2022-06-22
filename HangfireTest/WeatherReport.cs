using HangfireTest.Service;
using System.Diagnostics;

namespace HangfireTest
{
    public class WeatherReport : IWeatherReport
    {
        ICoreService _service;
        public WeatherReport(ICoreService service)
        {
            _service = service;
        }
        public static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        public void ReportWeather()
        {
            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            foreach (var item in array)
            {
                Debug.Write(item.Date + " | ");
                Debug.Write(item.TemperatureC + " | ");
                _service.ConvertNumberToText(item.TemperatureC, out string text);
                Debug.Write(text + " | ");
                Debug.WriteLine(item.Summary);
                Debug.WriteLine("".PadRight(40, '*'));
            }
        }
        public void ReportWeather2()
        {
            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            foreach (var item in array)
            {
                //if (item.TemperatureC > 50) { throw new Exception("OverFlowe Hottt!"); }
                Debug.Write("2." + item.Date + " | ");
                Debug.Write(item.TemperatureC + " | ");
                _service.ConvertNumberToText(item.TemperatureC, out string text);
                Debug.Write(text + " | ");
                Debug.WriteLine("2." + item.Summary);
                Debug.WriteLine("".PadRight(40, '*'));
            }
        }
    }
}
