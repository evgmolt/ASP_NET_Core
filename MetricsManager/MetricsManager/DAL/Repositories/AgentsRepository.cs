using Core;
using Dapper;
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
    public class IAgentsRepository : IAgentsRepository<AgentInfo>
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public IAgentsRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration.GetValue<string>("ConnectionString");
        }

        public void RegisterAgent(AgentInfo item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute("INSERT INTO " + Strings.AgentsTableName + "(AgentAddress, Enabled) VALUES(@AgentAddress, @Enabled)",
                new
                {
                    AgentAddress = item.AgentAddress,
                    Enabled = item.Enabled
                });
            }
        }

        public void EnableAgentById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute("UPDATE " + Strings.AgentsTableName + " SET enabled = @enabled WHERE id = @id",
                new { id = id, enabled = true });
            }
        }

        public void DisableAgentById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute("UPDATE " + Strings.AgentsTableName + " SET enabled = @enabled WHERE id = @id",
                new { id = id, enabled = false });
            }
        }

        public AgentInfo GetAgentById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.QuerySingle<AgentInfo>("SELECT Id, AgentAddress, Enabled FROM " + Strings.AgentsTableName + " WHERE id = @id",
                new { id = id });
            }
        }

        public IList<AgentInfo> GetAgentsList()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                return connection.Query<AgentInfo>("SELECT Id, AgentAddress, Enabled FROM " + Strings.AgentsTableName).ToList();
            }
        }
    }
}
