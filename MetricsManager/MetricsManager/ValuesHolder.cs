using System.Collections.Generic;

namespace MetricsManager
{
    public class ValuesHolder
    {
        public List<string> Values { get; set; }
        public List<WeatherForecast> TempList { get; set; }

        public ValuesHolder()
        {
            Values = new List<string>();
            TempList = new List<WeatherForecast>();
        }
    }
}