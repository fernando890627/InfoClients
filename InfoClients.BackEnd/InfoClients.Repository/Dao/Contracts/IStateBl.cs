using InfoClients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Repository.Dao
{
    public interface IStateBl
    {
        IQueryable<State> Get();

        IQueryable<State> GetByCountry(int countryId);
    }
}
