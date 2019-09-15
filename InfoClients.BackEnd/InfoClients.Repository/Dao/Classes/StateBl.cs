using InfoClients.Model;
using InfoClients.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Repository.Dao.Classes
{
    public class StateBl:IStateBl
    {
        private readonly IRepository<State> _stateRepository;
        public StateBl(IRepository<State> stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public IQueryable<State> Get()
        {
            return _stateRepository.GetAll();
        }

        public IQueryable<State> GetByCountry(int countryId)
        {
            return _stateRepository.Query(m=>m.CountryId.Equals(countryId));
        }
    }
}
