using InfoClients.Model;
using InfoClients.Repository.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Service.Classes
{
    public class CountryService:ICountryService
    {
        private readonly ICountryBl _countryBl;

        public CountryService(ICountryBl countryBl)
        {
            _countryBl = countryBl;
        }
        public IQueryable<Country> Get()
        {
            return _countryBl.Get();
        }
    }
}
