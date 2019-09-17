using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoClients.Model
{
    public partial class Country
    {
        public Country()
        {
            State = new HashSet<State>();
        }
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<State> State { get; set; }
    }
}
