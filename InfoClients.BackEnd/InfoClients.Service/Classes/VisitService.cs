using InfoClients.Model;
using InfoClients.Repository.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoClients.Service.Classes
{
    public class VisitService:IVisitService
    {
        private readonly IVisitBl _visitBl;

        public VisitService(IVisitBl visitBl)
        {
            _visitBl = visitBl;
        }
        public Visit Add(Visit objVisit)
        {
            return _visitBl.Add(objVisit);
        }

        public IQueryable<Visit> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Visit> GetByCity(int cityId)
        {
            return _visitBl.GetByCity(cityId);
        }

        public IQueryable<Visit> GetByClient(int clientId)
        {
            return _visitBl.GetByClient(clientId);
        }
    }
}
