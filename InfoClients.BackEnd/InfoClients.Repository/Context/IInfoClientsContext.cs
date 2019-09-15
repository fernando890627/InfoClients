using InfoClients.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Repository
{
    public interface IInfoClientsContext
    {
        DbSet<City> City { get; set; }
        DbSet<Client> Client { get; set; }
        DbSet<Country> Country { get; set; }
        DbSet<SalePerson> SalePerson { get; set; }
        DbSet<State> State { get; set; }
        DbSet<Visit> Visit { get; set; }
    }
}
