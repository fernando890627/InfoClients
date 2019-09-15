using InfoClients.Model;
using InfoClients.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Repository.Dao.Classes
{
    public class SalePersonBl:ISalePersonBl
    {
        private readonly IRepository<SalePerson> _salePersonRepository;
        public SalePersonBl(IRepository<SalePerson> salePersonRepository)
        {
            _salePersonRepository = salePersonRepository;
        }
    }
}
