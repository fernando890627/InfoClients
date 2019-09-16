using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoClients.Model;

namespace InfoClients.Repository.Dao
{
    public interface ISalePersonBl
    {
        IQueryable<SalePerson> Get();
    }
}
