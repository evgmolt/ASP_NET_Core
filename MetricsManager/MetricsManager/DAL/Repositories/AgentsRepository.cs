using Core;
using Dapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.SqlSettings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Repositories
{
    public class AgentsRepository : IAgentsRepository<AgentInfo>
    {
        private ISqlSettingsProvider _sqlSettingsProvider;
        private string _connectionString;

        public AgentsRepository(ISqlSettingsProvider sqlSettingsProvider)
        {
            _sqlSettingsProvider = sqlSettingsProvider;
            _connectionString = _sqlSettingsProvider.GetConnectionString();
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
