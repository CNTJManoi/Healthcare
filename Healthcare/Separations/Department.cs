using Healthcare.Logic.Models;
using Healthcare.Logic.Reception.Models;
using Healthcare.Logic.Separations.Base;
using Healthcare.Logic.Separations.Models;

namespace Healthcare.Logic.Separations;

public class Department : IDepartment
{
    private readonly List<Cabinet> _cabinets;
    private readonly List<Doctor> _doctors;
    private readonly List<Patient> _patients;

    private Department(string name,
        string address, int numberOfFloors,
        TypeDepartment typeDepartment, Guid id)
    {
        Id = id;
        Name = name;
        Address = address;
        NumberOfFloors = numberOfFloors;
        TypeDepartment = typeDepartment;
    }

    public Department(IEnumerable<Cabinet> cabinets, IEnumerable<Doctor> doctors, IEnumerable<Patient> patients,
        string name,
        string address, int numberOfFloors,
        TypeDepartment typeDepartment, Guid id) : this(name, address, numberOfFloors, typeDepartment, id)
    {
        _cabinets = cabinets.ToList();
        _doctors = doctors.ToList();
        _patients = Patients.ToList();
    }

    /// <summary>
    ///     Идентификационный номер отделения
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Исчисляемый список имеющихся кабинетов в отделении
    /// </summary>
    public IEnumerable<Cabinet> Cabinets => _cabinets;

    /// <summary>
    ///     Исчисляемый список работающих докторов в отделении
    /// </summary>
    public IEnumerable<Doctor> Doctors => _doctors;

    /// <summary>
    ///     Исчисляемый список пациентов в отделении
    /// </summary>
    public IEnumerable<Patient> Patients => _patients;

    /// <summary>
    ///     Наименование отделения
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Адрес отделения
    /// </summary>
    public string Address { get; }

    /// <summary>
    ///     Количество этажей в отделении
    /// </summary>
    public int NumberOfFloors { get; set; }

    /// <summary>
    ///     Тип отделения
    /// </summary>
    public TypeDepartment TypeDepartment { get; set; }

    /// <summary>
    ///     Добавить кабинет в отделение
    /// </summary>
    /// <param name="cb">Экземпляр класса кабинета</param>
    public void AddCabinet(Cabinet cb)
    {
        _cabinets.Add(cb);
    }

    /// <summary>
    ///     Добавить нового доктора в отделение
    /// </summary>
    /// <param name="dt">Экземпляр класса доктора</param>
    public void AddDoctor(Doctor dt)
    {
        _doctors.Add(dt);
    }

    /// <summary>
    ///     Добавить нового пациента в отделение
    /// </summary>
    /// <param name="pt">Экземплр класса пациента</param>
    public void AddPatient(Patient pt)
    {
        _patients.Add(pt);
    }

    /// <summary>
    ///     Уволить доктора с отделения
    /// </summary>
    /// <param name="dt">Экземпляр класса доктора</param>
    public void DismissDoctor(Doctor dt)
    {
        _doctors.Remove(dt);
    }

    /// <summary>
    ///     Выписать пациента с отделения
    /// </summary>
    /// <param name="pt">Экземпляр класса пациента</param>
    public void DischargePatient(Patient pt)
    {
        _patients.Remove(pt);
    }

    /// <summary>
    ///     Добавить новую запись к врачу в отделении
    /// </summary>
    /// <param name="doctor">Экземпляр класса доктора</param>
    /// <param name="pt">Экземпляр класса пациента</param>
    /// <param name="dt">Время записи</param>
    /// <returns>Экземпляр класса записи</returns>
    public Record? AddRecord(Doctor doctor, Patient pt, DateTime dt)
    {
        foreach (var cabinet in _cabinets.Where(cabinet =>
                     cabinet.TypeDoctor == doctor.SpecializationDoctor && !cabinet.CabinetIsBusy(doctor)))
            //_cabinets[_cabinets.IndexOf(cabinet)].EnterCabient(doctor);
            return new Record(dt, Guid.NewGuid(), cabinet, doctor, pt);

        return null;
    }
}