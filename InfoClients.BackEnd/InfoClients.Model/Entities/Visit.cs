using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoClients.Model
{
    public partial class Visit
    {
        [Key]
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
