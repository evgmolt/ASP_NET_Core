using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
//      Пытаюсь "дернуть" этот метод следующим запросом:
//      POST http://localhost:5000/api/agents/register
//      BODY:
//        {
//              "AgentId" : 333,
//              "AgentAddress" : 111111
//        }
//      Не получается получить параметр, AgentInfo - 0 и null. JSON неправильный, или что?
            return Ok();
        }
        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }
        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpGet("getagents")]
        public IActionResult GetAgentsList()
        {
            return Ok();
        }
    }
}
