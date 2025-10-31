using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyLibrary.Models
{
    public class ZelisTechnologyDBContext : DbContext
    {
        public ZelisTechnologyDBContext() { }
        public ZelisTechnologyDBContext(DbContextOptions<ZelisTechnologyDBContext> options) { }

        public DbSet<Technology> Technologies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=BlazorTechnologyDB; integrated security=true");
            }
        }
    }
}
