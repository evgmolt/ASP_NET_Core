using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager
{
    public  static class PercentileCounter
    {
        private static int[] _percentsArray = new[] { 50, 75, 90, 95, 99 };

        public static int GetPercentile(int[] sequence, int percentilenum)
        {
            double index = _percentsArray[percentilenum] * sequence.Length / 100;
            return sequence[(int)index];
        }
    }
}
