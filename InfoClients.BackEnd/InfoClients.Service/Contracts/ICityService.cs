using InfoClients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Service
{
    public interface ICityService
    {
        IQueryable<City> Get();
        IQueryable<City> GetByState(int stateId);
    }
}
