using Healthcare.Reception.Models;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Database;

internal class DatabaseManager
{
    public DatabaseManager()
    {
        ApplicationContext = new ApplicationContext();
    }

    //public DbSet<Doctor> Doctors => Set<Doctor>();
    //public DbSet<Patient> Patients => Set<Patient>();
    //public DbSet<Record> Records => Set<Record>();
    //public DbSet<Department> Departments => Set<Department>();
    //public DbSet<Hospital> Hospital => Set<Hospital>();
    private ApplicationContext ApplicationContext { get; }
    public Hospital LoadDatabase()
    {
        try
        {
            var hp = ApplicationContext.Hospital.ToList()[0];
            foreach (var department in ApplicationContext.Departments
                         .Include(x => x.Cabinets)
                         .Include(x => x.Patients)
                         .Include(x => x.Doctors)
                         .ToList())
                hp.AddDepartment(department);
            foreach (var record in ApplicationContext.Records
                         .ToList())
                hp.ReceptionHospital.RegistrationRecord(record);
            return hp;
        }
        catch
        {
            return null;
        }
    }

    public void SaveRecord(Record record)
    {
        ApplicationContext.Records.Add(record);
        ApplicationContext.SaveChanges();
    }
    public void Close()
    {
        ApplicationContext.Database.CloseConnection();
        ApplicationContext.Dispose();
    }
}