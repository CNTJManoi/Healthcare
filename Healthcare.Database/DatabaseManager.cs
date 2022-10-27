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

    /// <summary>
    ///     Загрузить данные с базы данных
    /// </summary>
    /// <returns></returns>
    public Hospital LoadDatabase()
    {
        try
        {
            var hp = ApplicationContext.Hospital.ToList()[0];
            foreach (var department in ApplicationContext.Departments
                         .Include(x => x.Patients)
                         .Include(x => x.Doctors)
                         .Include(x => x.Cabinets)
                         .ToList())
                hp.AddDepartment(department);

            foreach (var record in ApplicationContext.Records
                         .Include(x => x.AttachedCabinet)
                         .Include(x => x.RegisteredPatient)
                         .Include(x => x.ResponsibleDoctor)
                         .ToList())
                hp.ReceptionHospital.RegistrationRecord(record);

            return hp;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    ///     Записать запись в базу данных
    /// </summary>
    /// <param name="record">Экземпляр класса записи</param>
    public void SaveRecord(Record record)
    {
        if (record == null) throw new ArgumentNullException(nameof(record));
        ApplicationContext.Records.Add(record);
        ApplicationContext.SaveChanges();
    }

    /// <summary>
    ///     Закрыть соединение с базой данных
    /// </summary>
    public void Close()
    {
        ApplicationContext.Database.CloseConnection();
        ApplicationContext.Dispose();
    }
}