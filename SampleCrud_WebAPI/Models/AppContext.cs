using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCrud_WebAPI.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
