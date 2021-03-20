using System.Collections.Generic;

namespace MetricsManager
{
    public class ValuesHolder
    {
        public List<string> Values { get; set; }
        public List<WeatherForecast> TemperatureList { get; set; }

        public ValuesHolder()
        {
            Values = new List<string>();
            TemperatureList = new List<WeatherForecast>();
        }
    }
}