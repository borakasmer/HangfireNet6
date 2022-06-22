using Hangfire;
using HangfireTest.Service;
using Microsoft.AspNetCore.Mvc;

namespace HangfireTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        ICoreService _service;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICoreService service)
        {
            _logger = logger;
            _service = service;
        }


        //https://crontab.guru/#32_13_*_*_*
        [HttpPost]
        [Route("[action]")]
        public IActionResult GetHourlyWeatherReport()
        {
            WeatherReport weather = new(_service);
            //RecurringJob.AddOrUpdate(() => weather.ReportWeather(), "32 13 * * *");
            //RecurringJob.RemoveIfExists()
            RecurringJob.AddOrUpdate(() => weather.ReportWeather(), Cron.Daily(10, 38)); //1:38
            RecurringJob.AddOrUpdate(() => weather.ReportWeather2(), "2 * * * *"); //Every 2 minute            
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult GetWeatherReportOnce()
        {
            WeatherReport weather = new(_service);
            BackgroundJob.Schedule(() => weather.ReportWeather(), TimeSpan.FromSeconds(0));

            return Ok();
        }
    }
}