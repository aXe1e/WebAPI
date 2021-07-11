using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly ILogger<AgentsController> _logger;

        public AgentsController(ILogger<AgentsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в AgentsController.");
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _logger.LogInformation($"Запуск AgentsController.RegisterAgent с параметрами: {agentInfo.AgentId}, {agentInfo.AgentAddress}.");
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation($"Запуск AgentsController.EnableAgentById с параметрами: {agentId}.");
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation($"Запуск AgentsController.DisableAgentById с параметрами: {agentId}.");
            return Ok();
        }

        [HttpGet("list/agents")]
        public IActionResult ListAgents()
        {
            _logger.LogInformation($"Запуск AgentsController.ListAgents.");
            return Ok();
        }

    }
   

}
