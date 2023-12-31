﻿using GymClientControl.Domain.InputModels.v1.Client;
using GymClientControl.Domain.Services.v1.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GymClientControl.Controllers.v1.Client
{
    [ApiController]
    [Route("api/v1/Clients")]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllAsync();

            return Ok(clients);
        }

        [HttpGet("{document}")]
        public async Task<IActionResult> GetByDocument(string document)
        {
            var client = await _clientService.GetByDocumentAsync(document);

            if (client is null)
                return NotFound($"Client with document: '{document}', not found");

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewClient([FromBody] NewClientInputModel newClient)
        {
            var client = await _clientService.GetByDocumentAsync(newClient.Document);

            if (client is not null)
                return NotFound($"There is already a customer registered with this document: '{newClient.Document}'");

            var clientRegisteredDocument = await _clientService.RegisterNewClient(newClient);

            if (clientRegisteredDocument is null)
                return BadRequest("Client not registered");

            return CreatedAtAction(nameof(RegisterNewClient), new { document = clientRegisteredDocument, newClient });
        }

        [HttpPut("activate/{document}")]
        public async Task<IActionResult> ActivateClient(string document)
        {
            var updateClient = await _clientService.GetByDocumentAsync(document);

            if (updateClient is null)
                return NotFound($"Client not found with document: '{document}'");

            _clientService.ActivateClient(document);

            return NoContent();
        }

        [HttpPut("update/{document}")]
        public async Task<IActionResult> UpdateClient(string document, UpdateClientInputModel updateClientModel)
        {
            var updateClient = await _clientService.GetByDocumentAsync(document);

            if (updateClient is null)
                return NotFound($"Client not found with document: '{document}'");

            _clientService.UpdateClient(document, updateClientModel);

            return NoContent();
        }

        [HttpDelete("{document}")]
        public async Task<IActionResult> DeleteClient(string document)
        {
            var deleteClient = await _clientService.GetByDocumentAsync(document);

            if (deleteClient is null)
                return NotFound($"Client with document: '{document}', not found");

            _clientService.DeleteClient(document);

            return NoContent();
        }
    }
}
