using InfoClients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Repository.Dao
{
    public interface IClientBl
    {
        Client Add(Client objClient);

        IQueryable<Client> Get();
        void Delete(int id);

        Client Get(int id);
    }
}
