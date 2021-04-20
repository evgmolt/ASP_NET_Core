using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Interfaces
{
    public interface IAgentsRepository<AgentInfo>
    {
        void RegisterAgent(AgentInfo item);

        void EnableAgentById(int agentId);

        void DisableAgentById(int agentId);

        IList<AgentInfo> GetAgentsList();

        AgentInfo GetAgentById(int id);
    }
}
