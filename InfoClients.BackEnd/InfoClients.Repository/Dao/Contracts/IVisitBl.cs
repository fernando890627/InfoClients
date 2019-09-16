using InfoClients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Repository.Dao
{
    public interface IVisitBl
    {
        Visit Add(Visit objVisit);
        IQueryable<Visit> GetByCity(int cityId);

        IQueryable<Visit> GetByClient(int clientId);
    }
}
