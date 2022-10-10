using Healthcare.Models;
using Healthcare.Separations.Base;

namespace Healthcare;

internal class Hospital
{
    private readonly List<IDepartment> _buildings;

    public Hospital(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        ReceptionHospital = new Reception.Reception();
        _buildings = new List<IDepartment>();
    }

    public Reception.Reception ReceptionHospital { get; }
    public IEnumerable<IDepartment> Buildings => _buildings;
    public Guid Id { get; }

    public string Name { get; set; }

    public void AddDepartment(IDepartment department)
    {
        _buildings.Add(department);
    }

    public void AddPatient(Patient CurrentPatient, int numberDepartment)
    {
        _buildings.ToList()[numberDepartment - 1].AddPatient(CurrentPatient);
    }

    public void AddDoctor(Doctor dt, int numberDepartment)
    {
        _buildings.ToList()[numberDepartment - 1].AddDoctor(dt);
    }
}