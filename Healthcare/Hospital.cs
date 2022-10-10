using Healthcare.Models;
using Healthcare.Models.Separations;
using Healthcare.Models.Separations.Base;
using Healthcare.Models.Separations.Models;

namespace Healthcare;

internal class Hospital
{
    private readonly List<IDepartment> _buildings;

    public Hospital(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        ReceptionHospital = new Reception();
        _buildings = new List<IDepartment>();
    }

    public Reception ReceptionHospital { get; }
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