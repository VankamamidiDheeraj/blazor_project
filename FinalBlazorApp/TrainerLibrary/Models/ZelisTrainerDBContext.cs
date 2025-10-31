using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerLibrary.Models
{
    public class ZelisTrainerDBContext:DbContext
    {
        public ZelisTrainerDBContext() { }
        public ZelisTrainerDBContext(DbContextOptions<ZelisTrainerDBContext> options) { }

        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=BlazorTrainerDB; integrated security=true");
            }
        }
    }
}
