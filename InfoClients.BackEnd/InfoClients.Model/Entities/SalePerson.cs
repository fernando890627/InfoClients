using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoClients.Model
{
    public partial class SalePerson
    {
        public SalePerson()
        {
            Visit = new HashSet<Visit>();
        }

        [Key]
        public int SalePersonId { get; set; }
        public string Name { get; set; }

        public ICollection<Visit> Visit { get; set; }
    }
}
