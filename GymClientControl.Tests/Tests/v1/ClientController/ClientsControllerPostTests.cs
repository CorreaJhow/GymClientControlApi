using GymClientControl.Controllers.v1.Client;
using GymClientControl.Domain.Entities.v1.Client;
using GymClientControl.Domain.Enums.v1;
using GymClientControl.Domain.InputModels.v1.Client;
using GymClientControl.Domain.Services.v1.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GymClientControl.Tests.Tests.v1.ClientController
{
    public class ClientsControllerPostTests
    {
        private readonly ClientsController _clientController;
        private readonly Mock<IClientService> _clientApplicationServiceMock;

        public ClientsControllerPostTests()
        {
            _clientApplicationServiceMock = new Mock<IClientService>();

            _clientController = new ClientsController(_clientApplicationServiceMock.Object);
        }

        [Fact]
        public async Task RegisterNewClient_WithNewClient_ReturnsCreatedResult()
        {
            var newClient = new NewClientInputModel("Test",
                                                    "123456789",
                                                    ContractTime.Semester,
                                                    DateTime.UtcNow,
                                                    "Test@gmail.com",
                                                    "988665533");

            _clientApplicationServiceMock
                .Setup(x => x.GetByDocumentAsync(newClient.Document))
                .ReturnsAsync((Client)null);

            _clientApplicationServiceMock
                .Setup(x => x.RegisterNewClient(newClient))
                .ReturnsAsync("registeredDocument");

            var result = await _clientController.RegisterNewClient(newClient);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("RegisterNewClient", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task RegisterNewClientWithExistingClientReturnsNotFoundResult()
        {
            var existingClient = new Client();
            var newClient = new NewClientInputModel("Test",
                                                    "446951842",
                                                    ContractTime.Quarterly,
                                                    DateTime.UtcNow,
                                                    "Test2@gmail.com",
                                                    "988665533");

            _clientApplicationServiceMock
                .Setup(x => x.GetByDocumentAsync(newClient.Document))
                .ReturnsAsync(existingClient);

            var result = await _clientController.RegisterNewClient(newClient);

            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal($"There is already a customer registered with this document: '{newClient.Document}'", notFoundObjectResult.Value);
        }

        [Fact]
        public async Task RegisterNewClient_WithInvalidInput_ReturnsBadRequestResult()
        {
            var newClient = new NewClientInputModel();
            _clientController.ModelState.AddModelError("Document", "The Document field is required.");

            var result = await _clientController.RegisterNewClient(newClient);

            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Client not registered", badRequestObjectResult.Value);
        }
    }
}