using GymClientControl.Domain.Entities.v1.Client;
using GymClientControl.Domain.InputModels.v1.Client;

namespace GymClientControl.Domain.Services.v1.Contracts
{
    public interface IClientServicePersistence
    {
        Task<List<Client>> GetAllAsync();
        Task<Client> GetByDocumentAsync(string document);
        Task<string> RegisterNewClient(Client newClient);
        void UpdateClient(string document, UpdateClientInputModel updateClient);
        void DeleteClient(string document);
        void ActivateClient(string document);
    }
}
