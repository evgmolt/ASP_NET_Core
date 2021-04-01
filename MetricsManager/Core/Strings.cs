using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
//Наверное это неправильное решение для хранения строк, надеюсь, подскажете правильное
    public static class Strings
    {
            public static string[] TableNames = 
            {
                "cpumetrics",
                "dotnetmetrics",
                "hddmetrics",
                "networkmetrics",
                "rammetrics"
            };
    }
}
