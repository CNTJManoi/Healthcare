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
        private readonly StreamWriter _logStream = new StreamWriter("database.log", true);
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Record> Records => Set<Record>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Hospital> Hospital => Set<Hospital>();

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseMySQL("server=localhost;database=Hospital;user=root;password=");
                optionsBuilder.LogTo(_logStream.WriteLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка подключения к базе данных " + e.Data);
                Environment.Exit(1);
            }
        }
        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
    }
}
