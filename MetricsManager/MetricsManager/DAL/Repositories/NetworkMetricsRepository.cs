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
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        private string _tablename;
        private IConfiguration _configuration;
        private string _connectionString;

        public NetworkMetricsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString");
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
            _tablename = Strings.TableNames[(int)Enums.MetricsNames.Network];
        }

        public void Create(NetworkMetric item)
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

        public void Update(NetworkMetric item)
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

        public IList<NetworkMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.Query<NetworkMetric>("SELECT Id, AgentId, Time, Value FROM " + _tablename).ToList();
            }
        }

        public NetworkMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.QuerySingle<NetworkMetric>("SELECT Id, AgentId, Time, Value FROM " + _tablename + " WHERE id = @id",
                new { id = id });
            }
        }

        public IList<NetworkMetric> GetByTimePeriod(int agentid, DateTimeOffset timeFrom, DateTimeOffset timeTo)
        {
            long timefrom = timeFrom.ToUnixTimeSeconds();
            long timeto = timeTo.ToUnixTimeSeconds();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return (IList<NetworkMetric>)connection.Query<NetworkMetric>(
                    "SELECT Id, AgentId, Time, Value FROM " + _tablename + " WHERE AgentId = @agentid AND Time > @timefrom AND Time < @timeto",
                new { agentid = agentid, timefrom = timefrom, timeto = timeto });
            }
        }

        public NetworkMetric GetLast(int agentid)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.QuerySingle<NetworkMetric>(
                    "SELECT Id, AgentId, Time, Value FROM " + _tablename + " WHERE Id = (SELECT MAX(Id) FROM " + _tablename + ")",
                new { agentid = agentid });
            }
        }

        public IList<NetworkMetric> GetByTimePeriodSorted(int agentid, DateTimeOffset timeFrom, DateTimeOffset timeTo)
        {
            long timefrom = timeFrom.ToUnixTimeSeconds();
            long timeto = timeTo.ToUnixTimeSeconds();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return (IList<NetworkMetric>)connection.Query<NetworkMetric>(
                    "SELECT Id, AgentId, Time, Value FROM " + _tablename + " WHERE AgentId = @agentid AND Time > @timefrom AND Time < @timeto ORDER BY Value ASC",
                new { agentid = agentid, timefrom = timefrom, timeto = timeto });
            }
        }
    }

}
