using System;
using System.Collections.Generic;

namespace InfoClients.Model
{
    public partial class Country
    {
        public Country()
        {
            State = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<State> State { get; set; }
    }
}
