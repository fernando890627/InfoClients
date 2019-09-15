using InfoClients.Model;
using InfoClients.Repository.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Service.Classes
{
    public class CityService:ICityService
    {
        private readonly ICityBl _cityBl;

        public CityService(ICityBl cityBl)
        {
            _cityBl = cityBl;
        }
        public IQueryable<City> Get()
        {
            return _cityBl.Get();
        }

        public IQueryable<City> GetByState(int stateId)
        {
            return _cityBl.GetByState(stateId);
        }
    }
}
