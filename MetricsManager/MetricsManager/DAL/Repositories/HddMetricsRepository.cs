using Core;
using DAL;
using Dapper;
using MetricsManager.DAL;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Repositories
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
        private string _tablename;
        private IConfiguration _configuration;
        private string _connectionString;

        public HddMetricsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString");
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
            _tablename = Strings.TableNames[(int)Enums.MetricsNames.Cpu];
        }

        public void Create(HddMetric item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute("INSERT INTO " + _tablename + "(agentid, value, time) VALUES(@agentid, @value, @time)",
                new
                {
                    agentid = item.AgentId,
                    value = item.Value,
                    time = item.Time
                });
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute("DELETE FROM " + _tablename + " WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }

        public void Update(HddMetric item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute("UPDATE " + _tablename + " SET agebtid = @agentid, value = @value, time = @time WHERE id = @id",
                new
                {
                    agentid = item.AgentId,
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });
            }
        }

        public IList<HddMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.Query<HddMetric>("SELECT Id, AgentId, Time, Value FROM " + _tablename).ToList();
            }
        }

        public HddMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.QuerySingle<HddMetric>("SELECT Id, AgentId, Time, Value FROM " + _tablename + " WHERE id = @id",
                new { id = id });
            }
        }

        public IList<HddMetric> GetByTimePeriod(int agentid, DateTimeOffset timeFrom, DateTimeOffset timeTo)
        {
            long timefrom = timeFrom.ToUnixTimeSeconds();
            long timeto = timeTo.ToUnixTimeSeconds();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return (IList<HddMetric>)connection.Query<HddMetric>(
                    "SELECT Id, AgentId, Time, Value FROM " + _tablename + " WHERE AgentId = @agentid AND Time > @timefrom AND Time < @timeto",
                new { agentid = agentid, timefrom = timefrom, timeto = timeto });
            }
        }

        public HddMetric GetLast()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.QuerySingle<HddMetric>("SELECT Id, AgentId, Time, Value FROM " + _tablename + " WHERE Id = (SELECT MAX(Id) FROM " + _tablename);
            }
        }
    }
}
