using GymClientControl.Application.InputModels.v1.Client;
using GymClientControl.Domain.Services.v1.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GymClientControl.Controllers.v1.Client
{
    [ApiController]
    [Route("api/v1/Clients")]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientApplicationService;
        public ClientsController(IClientService clientApplicationService)
        {
            _clientApplicationService = clientApplicationService;
        }
         
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientApplicationService.GetAllAsync();

            return Ok(clients);
        }

        [HttpGet("{document}")]
        public async Task<IActionResult> GetByDocument(string document)
        {
            var client = await _clientApplicationService.GetByDocumentAsync(document);

            if (client is null)
                return NotFound($"Client with document: '{document}', not found");

            return Ok(client);
        }


        [HttpPost]
        public async Task<IActionResult> RegisterNewClient([FromBody] NewClientInputModel newClientInputModel)
        {
            var documentClientRegistered = await _clientApplicationService.RegisterNewClient(newClientInputModel);

            if (documentClientRegistered is null)
                return BadRequest("Client not registered");

            return CreatedAtAction(nameof(RegisterNewClient), new { documentClientRegistered });
        }

        //HttpDelete 

        //HttpPut

        //HttpGetActivesTrue 
    }
}
