using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.SqlSettings
{
    public class SqlSettingsProvider : ISqlSettingsProvider
    {
        private IConfiguration _configuration { get; }

        public SqlSettingsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetValue<string>("ConnectionString");
        }
    }
}
