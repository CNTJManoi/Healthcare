using Healthcare.Logic;
using Healthcare.Logic.Reception.Models;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Database;

public class DatabaseManager
{
    public DatabaseManager()
    {
        ApplicationContext = new ApplicationContext();
    }

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