using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    public class ZelisTrainingDBContext : DbContext
    {
        public ZelisTrainingDBContext() { }

        public ZelisTrainingDBContext(DbContextOptions<ZelisTrainingDBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=BlazorTrainingDB; integrated security=true");
            }
        }

    }
}