using InfoClients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Repository.Dao
{
    public interface ICityBl
    {
        IQueryable<City> Get();
        IQueryable<City> GetByState(int stateId);
    }
}
