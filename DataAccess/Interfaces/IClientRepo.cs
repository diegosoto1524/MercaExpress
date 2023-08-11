using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Interfaces
{
    public interface IClientRepo
    {
        bool CreateClient(Client client);
        bool ModifyCLient(int id, Client client);
        bool DeleteClient(int id);
        Client GetClientById(int id);
        List<Client> GetAllClients();


    }
}
