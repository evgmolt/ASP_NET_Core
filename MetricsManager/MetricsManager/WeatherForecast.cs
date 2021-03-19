using System;

namespace MetricsManager
{
    public class WeatherForecast
    {
        public WeatherForecast(DateTime datetime, int temperature, string summary)
        {
            Date = datetime;
            TemperatureC = temperature;
            Summary = summary;
        }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
