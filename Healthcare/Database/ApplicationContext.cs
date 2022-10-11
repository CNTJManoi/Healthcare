using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Models;
using Healthcare.Reception.Models;
using Healthcare.Separations;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Database
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Record> Records => Set<Record>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Hospital> Hospital => Set<Hospital>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
