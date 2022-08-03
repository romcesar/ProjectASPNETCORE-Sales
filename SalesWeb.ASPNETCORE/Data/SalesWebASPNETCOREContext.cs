using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWeb.ASPNETCORE.Models.Entities;

namespace SalesWeb.ASPNETCORE.Data
{
    public class SalesWebASPNETCOREContext : DbContext
    {
        public SalesWebASPNETCOREContext (DbContextOptions<SalesWebASPNETCOREContext> options)
            : base(options)
        {
        }

        public DbSet<Departaments> Departaments { get; set; }

        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
    }
}
