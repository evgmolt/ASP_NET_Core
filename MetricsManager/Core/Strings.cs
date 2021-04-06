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
        public const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=True;Max Pool Size=100;";
        public static string DbFileName = "metrics.db";
        public static string CronString = "0/{0} * * * * ?";
    }
}
