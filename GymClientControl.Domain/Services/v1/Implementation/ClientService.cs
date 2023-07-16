using GymClientControl.Domain.Entities.v1.Client;
using GymClientControl.Domain.InputModels.v1.Client;
using GymClientControl.Domain.Services.v1.Contracts;

namespace GymClientControl.Domain.Services.v1.Implementation
{
    public sealed class ClientService : IClientService
    {
        private IClientServicePersistence _clientServicePersistence;
        public ClientService(IClientServicePersistence clientRepository)
        {
            _clientServicePersistence = clientRepository;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _clientServicePersistence.GetAllAsync();
        }

        public async Task<Client> GetByDocumentAsync(string document)
        {
            return await _clientServicePersistence.GetByDocumentAsync(document);
        }

        public async Task<string> RegisterNewClient(NewClientInputModel newClientInputModel)
        {
            var newClient = new Client(newClientInputModel.Name,
                                       newClientInputModel.DateBirth,
                                       newClientInputModel.Phone,
                                       newClientInputModel.Document,
                                       newClientInputModel.Email,
                                       newClientInputModel.ContractTime);

            return await _clientServicePersistence.RegisterNewClient(newClient);
        }

        public void UpdateClient(string document, UpdateClientInputModel updateClient)
        {
            _clientServicePersistence.UpdateClient(document, updateClient);
        }

        public void DeleteClient(string document)
        {
            _clientServicePersistence.DeleteClient(document);
        }

        public void ActivateClient(string document)
        {
            _clientServicePersistence.ActivateClient(document);
        }
    }
}

