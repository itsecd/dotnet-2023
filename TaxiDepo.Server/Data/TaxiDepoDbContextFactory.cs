using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaxiDepo.Model;

    public class TaxiDepoDbContextFactory : DbContext
    {
        public TaxiDepoDbContextFactory (DbContextOptions<TaxiDepoDbContextFactory> options)
            : base(options)
        {
        }

        public DbSet<TaxiDepo.Model.Car> Car { get; set; } = default!;

        public DbSet<TaxiDepo.Model.Driver>? Driver { get; set; }

        public DbSet<TaxiDepo.Model.Ride>? Ride { get; set; }

        public DbSet<TaxiDepo.Model.User>? User { get; set; }
    }
