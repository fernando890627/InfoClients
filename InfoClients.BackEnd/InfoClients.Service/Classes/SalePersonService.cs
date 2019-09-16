using InfoClients.Model;
using InfoClients.Repository.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Service.Classes
{
    public class SalePersonService:ISalePersonService
    {
        private readonly ISalePersonBl _salePersonBl;

        public SalePersonService(ISalePersonBl salePersonBl)
        {
            _salePersonBl = salePersonBl;
        }
        public IQueryable<SalePerson> Get()
        {
            return _salePersonBl.Get();
        }
    }
}
