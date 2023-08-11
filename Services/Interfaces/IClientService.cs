using Entities;
using MercaExpress;

namespace MercaExpress.Services
{
    public interface IClientService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        bool CreateClient(Client client);
        bool ModifyCLient(int id, Client client);
        bool DeleteClient(int id);
        Client GetClientById(int id);
        List<Client> GetAllClients();
    }
}
