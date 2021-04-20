using AutoMapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.DAL.Repositories;
using MetricsManager.Responses;
using MetricsManager.Responses.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private IAgentsRepository<AgentInfo> _repository;
        private readonly ILogger<AgentsController> _logger;
        private readonly IMapper _mapper;
        private IConfiguration _configuration;

        public AgentsController(
            ILogger<AgentsController> logger,
            IAgentsRepository<AgentInfo> repository,
            IMapper mapper,
            IConfiguration configuration)
        {
            this._configuration = configuration;
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
            _logger.LogDebug(1, "NLog встроен в AgentsController");
        }

        [HttpPost("register/address/{agentAddress}")]
        public IActionResult RegisterAgent([FromRoute] string agentAddress)
        {
            string http = "http://";
            _repository.RegisterAgent(new AgentInfo() { AgentAddress = http + agentAddress, Enabled = true } );
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _repository.EnableAgentById(agentId);
            return Ok();
        }
        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _repository.DisableAgentById(agentId);
            return Ok();
        }

        [HttpGet("getagents")]
        public IActionResult GetAgentsList()
        {
            var metrics = _repository.GetAgentsList();
            var response = new AgentResponse()
            {
                Metrics = new List<AgentInfoDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<AgentInfoDto>(metric));
            }

            return Ok(response);
        }
    }
}
