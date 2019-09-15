using InfoClients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Service
{
    public interface IStateService
    {
        IQueryable<State> Get();
        IQueryable<State> GetByCountry(int countryId);
    }
}
