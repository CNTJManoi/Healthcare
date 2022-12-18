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
    /// <summary>
    /// Отделение, находящиеся в больнице
    /// </summary>
    /// <param name="name"></param>
    /// <param name="address"></param>
    /// <param name="numberOfFloors"></param>
    /// <param name="typeDepartment"></param>
    /// <param name="id"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    private Department(string name,
        string address, int numberOfFloors,
        TypeDepartment typeDepartment, Guid id)
    {
        if (numberOfFloors < 0) throw new ArgumentOutOfRangeException(nameof(numberOfFloors));
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Address = address ?? throw new ArgumentNullException(nameof(address));
        NumberOfFloors = numberOfFloors;
        TypeDepartment = typeDepartment;
    }

    public Department(IEnumerable<Cabinet> cabinets, IEnumerable<Doctor> doctors, IEnumerable<Patient> patients,
        string name,
        string address, int numberOfFloors,
        TypeDepartment typeDepartment, Guid id) : this(name, address, numberOfFloors, typeDepartment, id)
    {
        if (cabinets == null) throw new ArgumentNullException(nameof(cabinets));
        if (doctors == null) throw new ArgumentNullException(nameof(doctors));
        if (patients == null) throw new ArgumentNullException(nameof(patients));
        _cabinets = cabinets.ToList();
        _doctors = doctors.ToList();
        _patients = patients.ToList();
    }

    /// <summary>
    ///     Идентификационный номер отделения
    /// </summary>
    public Guid Id { get; }

    public IEnumerable<Cabinet> Cabinets => _cabinets;


    public IEnumerable<Doctor> Doctors => _doctors;


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
    /// <param name="cb"></param>
    public void AddCabinet(Cabinet cb)
    {
        if (cb == null) throw new ArgumentNullException(nameof(cb));
        _cabinets.Add(cb);
    }

    /// <summary>
    ///     Добавить нового доктора в отделение
    /// </summary>
    /// <param name="dt"></param>
    public void AddDoctor(Doctor dt)
    {
        if (dt == null) throw new ArgumentNullException(nameof(dt));
        _doctors.Add(dt);
    }

    /// <summary>
    ///     Добавить нового пациента в отделение
    /// </summary>
    /// <param name="pt"></param>
    public void AddPatient(Patient pt)
    {
        if (pt == null) throw new ArgumentNullException(nameof(pt));
        _patients.Add(pt);
    }

    /// <summary>
    ///     Добавить новую запись к врачу в отделении
    /// </summary>
    /// <param name="doctor"></param>
    /// <param name="pt"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public Record AddRecord(Doctor doctor, Patient pt, DateTime dt)
    {
        if (doctor == null) throw new ArgumentNullException(nameof(doctor));
        if (pt == null) throw new ArgumentNullException(nameof(pt));
        foreach (var cabinet in _cabinets.Where(cabinet =>
                     cabinet.TypeDoctor == doctor.SpecializationDoctor && !cabinet.CabinetIsBusy(doctor)))
        {
            _cabinets[_cabinets.IndexOf(cabinet)].EnterCabinet(doctor);
            return new Record(dt, Guid.NewGuid(), cabinet, doctor, pt);
        }

        throw new ArgumentNullException(nameof(Record));
    }
}