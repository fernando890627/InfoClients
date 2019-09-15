using InfoClients.Model;
using InfoClients.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Repository.Dao.Classes
{
    public class VisitBl:IVisitBl
    {
        private readonly IRepository<Visit> _visitRepository;
        public VisitBl(IRepository<Visit> visitRepository)
        {
            _visitRepository = visitRepository;
        }
    }
}
