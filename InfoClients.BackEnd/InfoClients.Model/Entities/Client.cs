using System;
using System.Collections.Generic;

namespace InfoClients.Model
{
    public partial class Client
    {
        public Client()
        {
            Visit = new HashSet<Visit>();
        }

        public int ClientId { get; set; }
        public string Nit { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public int? CreditLimit { get; set; }
        public int? AvailableCredit { get; set; }
        public decimal? VisitsPercentage { get; set; }
        public ICollection<Visit> Visit { get; set; }
    }
}
