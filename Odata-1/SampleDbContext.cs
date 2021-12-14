using Microsoft.EntityFrameworkCore;
using Odata_1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odata_1
{
    public class SampleDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
         : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Sale> Sale { get; set; }



    }
}
