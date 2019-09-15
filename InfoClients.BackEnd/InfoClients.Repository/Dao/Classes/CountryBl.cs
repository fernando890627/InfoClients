using InfoClients.Model;
using InfoClients.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Repository.Dao.Classes
{
    public class CountryBl:ICountryBl
    {
        private readonly IRepository<Country> _countryRepository;
        public CountryBl(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IQueryable<Country> Get()
        {
            return _countryRepository.GetAll();
        }
    }
}
