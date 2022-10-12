using Healthcare.Models;
using Healthcare.Reception.Models;
using Healthcare.Separations.Base;
using Healthcare.Separations.Models;

namespace Healthcare.Separations;

internal class Department : IDepartment
{
    private List<Cabinet> _cabinets;
    private List<Doctor> _doctors;
    private List<Patient> _patients;

    public Department(List<Cabinet> cabinets, string name, string address, int numberOfFloors,
        TypeDepartment typeDepartment)
    {
        Id = new Guid();
        _cabinets = cabinets;
        Name = name;
        Address = address;
        NumberOfFloors = numberOfFloors;
        _doctors = new List<Doctor>();
        _patients = new List<Patient>();
        TypeDepartment = typeDepartment;
    }

    /// <summary>
    ///     Конструктор для базы данных
    /// </summary>
    public Department()
    {
    }

    public Guid Id { get; set; }

    public IEnumerable<Cabinet> Cabinets
    {
        get => _cabinets;
        set => _cabinets = value.ToList();
    }

    public IEnumerable<Doctor> Doctors
    {
        get => _doctors;
        set => _doctors = value.ToList();
    }

    public IEnumerable<Patient> Patients
    {
        get => _patients;
        set => _patients = value.ToList();
    }

    public string Name { get; set; }
    public string Address { get; set; }
    public int NumberOfFloors { get; set; }
    public TypeDepartment TypeDepartment { get; set; }

    public void AddCabinet(Cabinet cb)
    {
        _cabinets.Add(cb);
    }

    public void AddDoctor(Doctor dt)
    {
        _doctors.Add(dt);
    }

    public void AddPatient(Patient pt)
    {
        _patients.Add(pt);
    }

    public void DismissDoctor(Doctor dt)
    {
        _doctors.Remove(dt);
    }

    public void DischargePatient(Patient pt)
    {
        _patients.Remove(pt);
    }

    public Record? AddRecord(Doctor doctor, Patient pt, DateTime dt)
    {
        foreach (var cabinet in _cabinets.Where(cabinet =>
                     cabinet.TypeDoctor == doctor.SpecializationDoctor && !cabinet.CabinetIsBusy(doctor)))
        {
            _cabinets[_cabinets.IndexOf(cabinet)].EnterCabient(doctor);
            return new Record(doctor, pt, dt, cabinet, this);
        }

        return null;
    }
}