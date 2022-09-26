namespace Healthcare.Models.Separations;

internal class Polyclinic : IDataDepartment, IManageData
{
    private readonly List<Doctor> _doctors;
    private readonly List<Patient> _patients;

    public Polyclinic(List<Cabinet> cabinets, string name, string address, int numberOfFloors)
    {
        Id = new Guid();
        Cabinets = cabinets;
        Name = name;
        Address = address;
        NumberOfFloors = numberOfFloors;
        _doctors = new List<Doctor>();
        _patients = new List<Patient>();
    }

    public Guid Id { get; }
    public List<Cabinet> Cabinets { get; }

    public IEnumerable<Doctor> Doctors => _doctors;

    public IEnumerable<Patient> Patients => _patients;

    public string Name { get; set; }
    public string Address { get; }
    public int NumberOfFloors { get; set; }

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
}