using MetricsManager.Controllers;
using MetricsManager;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class AgentsControllerUnitTests
    {
        private AgentsController controller;
        private int agentId;
        private AgentInfo agentInfo;

        public AgentsControllerUnitTests()
        {
            controller = new AgentsController();
            agentId = 1;
            agentInfo = new AgentInfo();        
        }

        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            //Arrange
            
            //Act
            var result = controller.RegisterAgent(agentInfo);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            //Arrange
            
            //Act
            var result = controller.EnableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.DisableAgentById(agentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void ListAgents_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.ListAgents();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
