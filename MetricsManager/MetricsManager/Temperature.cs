using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager
{
    public class Temperature
    {
        public DateTime Date { get; set; }

        public int TemperatureValue { get; set; }

        public Temperature(DateTime datetime, int temperatureValue)
        {
            Date = datetime;
            TemperatureValue = temperatureValue;
        }
    }
}
