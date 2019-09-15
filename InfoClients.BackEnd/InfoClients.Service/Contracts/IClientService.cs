using InfoClients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Service
{
    public interface IClientService
    {
        IQueryable<Client> Get();

        Client Add(Client objClient);

        void Delete(int id);
        Client Get(int id);
    }
}
