using InfoClients.Model;
using InfoClients.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InfoClients.Repository.Dao.Classes
{
    public class VisitBl:IVisitBl
    {
        private readonly IRepository<Visit> _visitRepository;
        private readonly IClientBl _clientBl;
        
        public VisitBl(IRepository<Visit> visitRepository, IClientBl clientBl)
        {
            _visitRepository = visitRepository;
            _clientBl = clientBl;
        }

        public Visit Add(Visit objVisit)
        {
            Client objClient = _clientBl.Get(objVisit.ClientId ?? default(int));

            objClient.AvailableCredit -= 1;            
            objClient.VisitsPercentage = objClient.AvailableCredit / objClient.CreditLimit;

            objVisit.Net = objClient.CreditLimit - objClient.AvailableCredit;
            objVisit.VisitTotal = objVisit.Net * objClient.VisitsPercentage;
            _clientBl.Update(objClient);
            return _visitRepository.Add(objVisit);
        }

        public IQueryable<Visit> GetByCity(int cityId)
        {
            return _visitRepository.Get(filter: f => f.Client.CityId.Equals(cityId), orderBy: o => o.OrderByDescending(or => or.Date), includes: m => m.Client);
        }

        public IQueryable<Visit> GetByClient(int clientId)
        {
            return _visitRepository.Get(filter:f=>f.ClientId.Equals(clientId),orderBy:o=>o.OrderByDescending(or=>or.Date),includes: m => m.SalePerson);
        }
    }
}
