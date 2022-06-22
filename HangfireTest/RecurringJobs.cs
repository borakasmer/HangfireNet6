using Hangfire;
using HangfireTest.Service;

namespace HangfireTest
{
    //https://crontab.guru/#15_14_1_*_*
    public static class RecurringJobs
    {
        [Obsolete]
        public static void GetHourlyWeatherReport(ICoreService service)
        {
            WeatherReport weather = new(service);
            //RecurringJob.AddOrUpdate(() => weather.ReportWeather(), "32 13 * * *");
            //RecurringJob.RemoveIfExists("WeatherReport.ReportWeather");
            RecurringJob.RemoveIfExists(nameof(weather.ReportWeather));

            //RecurringJob.RemoveIfExists("WeatherReport.ReportWeather2");
            RecurringJob.RemoveIfExists(nameof(weather.ReportWeather2));

            RecurringJob.RemoveIfExists(nameof(weather.ReportWeather2) + "copy");

            //RecurringJob.AddOrUpdate(() => weather.ReportWeather(), Cron.Daily(11, 35)); //1:38
            //RecurringJob.AddOrUpdate(nameof(weather.ReportWeather), () => weather.ReportWeather(), Cron.Daily(16, 15), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time")); //16:15
            RecurringJob.AddOrUpdate<IWeatherReport>(nameof(weather.ReportWeather), x =>
            x.ReportWeather(), Cron.Daily(16, 15), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time")); //16:15

            //RecurringJob.AddOrUpdate(() => weather.ReportWeather2(), Cron.MinuteInterval(2)); //Every 2 minute           
            //RecurringJob.AddOrUpdate(nameof(weather.ReportWeather2), () => weather.ReportWeather2(), Cron.MinuteInterval(2), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time")); //Her 2 dakkada bir
            RecurringJob.AddOrUpdate<IWeatherReport>(nameof(weather.ReportWeather2), x =>
            x.ReportWeather2(), Cron.MinuteInterval(2), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time")); //Her 2 dakkada bir

            RecurringJob.AddOrUpdate<IWeatherReport>(nameof(weather.ReportWeather2) + "copy", x =>
            x.ReportWeather2(), Cron.Daily(17, 02), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time")); //Her Gün 17:02
        }
    }
}
