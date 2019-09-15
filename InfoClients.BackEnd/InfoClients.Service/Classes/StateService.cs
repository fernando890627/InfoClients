using InfoClients.Model;
using InfoClients.Repository.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Service.Classes
{
    public class StateService:IStateService
    {
        private readonly IStateBl _stateBl;

        public StateService(IStateBl stateBl)
        {
            _stateBl = stateBl;
        }
        public IQueryable<State> Get()
        {
            return _stateBl.Get();
        }

        public IQueryable<State> GetByCountry(int countryId)
        {
            return _stateBl.GetByCountry(countryId);
        }
    }
}
