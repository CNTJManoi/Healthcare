using Healthcare.Models.Separations.Base;
using Healthcare.Models.Separations.Models;

namespace Healthcare.Models.Separations;

internal class Department : IDepartment
{
    private readonly List<Doctor> _doctors;
    private readonly List<Patient> _patients;

    public Department(List<Cabinet> cabinets, string name, string address, int numberOfFloors , TypeDepartment typeDepartment)
    {
        Id = new Guid();
        Cabinets = cabinets;
        Name = name;
        Address = address;
        NumberOfFloors = numberOfFloors;
        _doctors = new List<Doctor>();
        _patients = new List<Patient>();
        TypeDepartment = typeDepartment;
    }

    public Guid Id { get; }
    public List<Cabinet> Cabinets { get; }

    public IEnumerable<Doctor> Doctors => _doctors;

    public IEnumerable<Patient> Patients => _patients;

    public string Name { get; set; }
    public string Address { get; }
    public int NumberOfFloors { get; set; }
    public TypeDepartment TypeDepartment { get; }

    public void AddCabinet(Cabinet cb)
    {
        Cabinets.Add(cb);
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

    public Record AddRecord(Doctor doctor, Patient pt, DateTime dt)
    {
        foreach (var cabinet in Cabinets)
            if (cabinet.TypeDoctor == doctor.SpecializationDoctor && !cabinet.CabinetIsBusy(doctor))
            {
                Cabinets[Cabinets.IndexOf(cabinet)].EnterCabient(doctor);
                return new Record(doctor, pt, dt, cabinet);
            }

        return null;
    }
}