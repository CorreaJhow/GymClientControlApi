using Dapper;
using GymClientControl.Domain.InputModels.v1.Client;
using GymClientControl.Domain.Services.v1.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace GymClientControl.Infrastructure.ImplementationPersistence.v1.Client
{
    public class ClientServicePersistence : IClientServicePersistence
    {
        private readonly string _connectionString;
        public ClientServicePersistence(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GymControl");
        }

        public async Task<List<Domain.Entities.v1.Client.Client>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Clients WHERE ActiveSubscription = 1";

                var clients = await sqlConnection.QueryAsync<Domain.Entities.v1.Client.Client>(sql);

                return clients.ToList();
            }
        }

        public async Task<Domain.Entities.v1.Client.Client> GetByDocumentAsync(string document)
        {
            var parameter = new { document };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Clients WHERE Document = @document";

                var clients = await sqlConnection.QuerySingleOrDefaultAsync<Domain.Entities.v1.Client.Client>(sql, parameter);

                return clients;
            }
        }

        public async Task<string> RegisterNewClient(Domain.Entities.v1.Client.Client newClient)
        {
            var parameters = new
            {
                newClient.Document,
                newClient.Name,
                newClient.DateBirth,
                newClient.Phone,
                newClient.Email,
                newClient.ActiveSubscription,
                newClient.ContractTime,
                newClient.RegistrationDate
            };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO Clients(Document, Name, DateBirth, Phone, Email, ActiveSubscription, ContractTime, RegistrationDate) " +
                                   "OUTPUT INSERTED.Document VALUES(@Document, @Name, @DateBirth, @Phone, @Email, @ActiveSubscription, @ContractTime, @RegistrationDate)";

                var returnDocument = await sqlConnection.ExecuteScalarAsync<string>(sql, parameters);

                return returnDocument;
            }
        }

        public void UpdateClient(string document, UpdateClientInputModel updateClient)
        {
            var parameters = new
            {
                document,
                updateClient.Name,
                updateClient.Phone,
                updateClient.DateBirth,
                updateClient.Email
            };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "UPDATE Clients SET Name = @Name, Phone = @Phone, DateBirth = @DateBirth, Email = @Email WHERE Document = @Document";

                sqlConnection.Execute(sql, parameters);
            }
        }
        public void DeleteClient(string document)
        {
            var parameters = new { document };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "UPDATE Clients SET ActiveSubscription = 0 WHERE Document = @document";

                sqlConnection.ExecuteAsync(sql, parameters);
            }
        }

        public void ActivateClient(string document)
        {
            var parameters = new { document };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "UPDATE Clients SET ActiveSubscription = 1 WHERE Document = @document";

                sqlConnection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
