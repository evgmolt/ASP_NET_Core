using System.Collections.Generic;

namespace MetricsManager
{
    public class TemperatureHolder
    {
        public List<Temperature> TemperatureList { get; set; }

        public TemperatureHolder()
        {
            TemperatureList = new List<Temperature>();
        }
    }
}