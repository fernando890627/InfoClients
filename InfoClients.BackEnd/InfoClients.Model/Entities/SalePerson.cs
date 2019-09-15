using System;
using System.Collections.Generic;

namespace InfoClients.Model
{
    public partial class SalePerson
    {
        public SalePerson()
        {
            Visit = new HashSet<Visit>();
        }

        public int SalePersonId { get; set; }
        public string Name { get; set; }

        public ICollection<Visit> Visit { get; set; }
    }
}
