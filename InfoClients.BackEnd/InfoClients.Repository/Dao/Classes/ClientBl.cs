using InfoClients.Model;
using InfoClients.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Repository.Dao.Classes
{
    public class ClientBl:IClientBl
    {
        private readonly IRepository<Client> _clientRepository;
        public ClientBl(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client Add(Client objClient)
        {
            return _clientRepository.Add(objClient);
        }

        public IQueryable<Client> Get()
        {
            return _clientRepository.GetAll();
        }



        public void Delete(int id)
        {
            _clientRepository.Delete(id);
        }

        public Client Get(int id)
        {
            return _clientRepository.Get(id);
        }

        public void Update(Client value)
        {
            _clientRepository.Update(value);
        }
    }
}
