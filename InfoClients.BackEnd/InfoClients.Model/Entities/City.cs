using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoClients.Model
{
    public partial class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StateId { get; set; }

        public State State { get; set; }
    }
}
