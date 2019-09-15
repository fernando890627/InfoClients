using InfoClients.Model;
using InfoClients.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Repository.Dao.Classes
{
    public class CityBl:ICityBl
    {
        private readonly IRepository<City> _cityRepository;
        public CityBl(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IQueryable<City> Get()
        {
            return _cityRepository.GetAll();
        }

        public IQueryable<City> GetByState(int stateId)
        {
            return _cityRepository.Query(c => c.StateId.Equals(stateId));
        }
    }
}
