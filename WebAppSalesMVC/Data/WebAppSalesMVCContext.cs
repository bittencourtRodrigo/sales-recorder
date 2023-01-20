using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppSalesMVC.Models;

namespace WebAppSalesMVC.Data
{
    public class WebAppSalesMVCContext : DbContext
    {
        public WebAppSalesMVCContext (DbContextOptions<WebAppSalesMVCContext> options)
            : base(options)
        {
        }

        public DbSet<State> State { get; set; }
        public DbSet<Subsidiary> Subsidiary { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
