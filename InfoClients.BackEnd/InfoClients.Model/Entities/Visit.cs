using System;
using System.Collections.Generic;

namespace InfoClients.Model
{
    public partial class Visit
    {
        public int VisitId { get; set; }
        public DateTime Date { get; set; }
        public int? Net { get; set; }
        public decimal? VisitTotal { get; set; }
        public string Description { get; set; }
        public int? SalePersonId { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public SalePerson SalePerson { get; set; }
    }
}
