﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoClients.Model
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
        }

        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<City> City { get; set; }
    }
}
