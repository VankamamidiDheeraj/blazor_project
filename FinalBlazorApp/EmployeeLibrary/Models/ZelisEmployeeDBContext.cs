using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary.Models
{
    public class ZelisEmployeeDBContext: DbContext
    {
        public ZelisEmployeeDBContext() { }
        public ZelisEmployeeDBContext(DbContextOptions<ZelisEmployeeDBContext> options) : base(options){}
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=BlazorEmployeeDB; integrated security=true");
            }
        }
    }
}
