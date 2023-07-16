using GymClientControl.Application.InputModels.v1.Client;
using GymClientControl.Domain.Entities.v1.Client;
using GymClientControl.Domain.Services.v1.Contracts;

namespace GymClientControl.Domain.Services.v1.Implementation
{
    public sealed class ClientService : IClientService
    {
        private IClientServicePersistence _clientRepository;
        public ClientService(IClientServicePersistence clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetByDocumentAsync(string document)
        {
            return await _clientRepository.GetByDocumentAsync(document);
        }

        public async Task<string> RegisterNewClient(NewClientInputModel newClientInputModel)
        {
            return await _clientRepository.RegisterNewClient(newClientInputModel);
        }
    }
}

