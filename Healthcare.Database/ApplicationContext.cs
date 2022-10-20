using Healthcare.Logic;
using Healthcare.Logic.Models;
using Healthcare.Logic.Reception.Models;
using Healthcare.Logic.Separations;
using Healthcare.Logic.Separations.Models;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Database;

public class ApplicationContext : DbContext
{
    private readonly StreamWriter _logStream = new("database.log", true);

    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Record> Records => Set<Record>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Hospital> Hospital => Set<Hospital>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hospital>(
            b =>
            {
                b.HasKey("Id");
                b.Property(e => e.Name);
            });

        modelBuilder.Entity<Doctor>(
            b =>
            {
                b.HasKey("Id");
                b.Property(b => b.Diplom);
                b.Property(b => b.BeginWorkTime);
                b.Property(b => b.EndWorkTime);
                b.Property(b => b.SpecializationDoctor);
                b.Property(b => b.Surname);
                b.Property(b => b.Name);
                b.Property(b => b.Society);
                b.Property(b => b.Address);
            });

        modelBuilder.Entity<Patient>(
            b =>
            {
                b.HasKey("Id");
                b.Property(b => b.Surname);
                b.Property(b => b.Name);
                b.Property(b => b.Society);
                b.Property(b => b.Address);
            });

        modelBuilder.Entity<Cabinet>(
            b =>
            {
                b.HasKey("Id");
                b.Property(b => b.TypeDoctor).IsRequired();
                b.Property(b => b.Number).IsRequired();
            });

        modelBuilder.Entity<Department>(
            b =>
            {
                b.HasKey("Id");
                b.HasMany(b => b.Cabinets);
                b.HasMany(b => b.Doctors);
                b.HasMany(b => b.Patients);
                b.Property(b => b.Name).IsRequired();
                b.Property(b => b.Address).IsRequired();
                b.Property(b => b.NumberOfFloors).IsRequired();
                b.Property(b => b.TypeDepartment).IsRequired();
            });

        modelBuilder.Entity<Record>(
            b =>
            {
                b.HasKey("Id");
                b.HasOne(b => b.RegisteredPatient);
                b.HasOne(b => b.ResponsibleDoctor);
                b.Property(b => b.RecordingTime);
                b.HasOne(b => b.AttachedCabinet);
            });
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