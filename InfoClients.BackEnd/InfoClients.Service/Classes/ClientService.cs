using InfoClients.Model;
using InfoClients.Repository.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Service.Classes
{
    public class ClientService:IClientService
    {
        private readonly IClientBl _clientBl;

        public ClientService(IClientBl clientBl)
        {
            _clientBl = clientBl;
        }

        public IQueryable<Client> Get()
        {
            return _clientBl.Get();
        }

        public Client Add(Client objClient)
        {
            return _clientBl.Add(objClient);
        }

        public void Delete(int id)
        {
            _clientBl.Delete(id);
        }

        public Client Get(int id)
        {
            return _clientBl.Get(id);
        }
    }
}
