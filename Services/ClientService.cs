using DataAccess;
using DataAccess.Interfaces;
using Entities;
using MercaExpress.Services;

namespace MercaExpress.Services
{
    public class ClientService : IClientService
    {
        IClientRepo clientRepo;
        public ClientService(IClientRepo clientRepo) 
        {
            this.clientRepo = clientRepo;
        }
         
        public bool CreateClient(Client client)
        {
            return clientRepo.CreateClient(client);
        }

        public bool DeleteClient(int id)
        {
            return (clientRepo.DeleteClient(id));
        }

        public List<Client> GetAllClients()
        {
            return clientRepo.GetAllClients();
        }

        public Client GetClientById(int id)
        {
            return clientRepo.GetClientById(id);
        }

        public bool ModifyCLient(int id, Client client)
        {
            return clientRepo.ModifyCLient(id, client);
        }
    }
}
