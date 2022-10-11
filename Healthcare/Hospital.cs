using System.ComponentModel.DataAnnotations;
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

    public Hospital()
    {

    }
    public Reception.Reception ReceptionHospital { get; }
    public IEnumerable<IDepartment> Buildings => _buildings;
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public void AddDepartment(IDepartment department)
    {
        _buildings.Add(department);
    }

    public void AddPatient(Patient currentPatient, int numberDepartment)
    {
        _buildings.ToList()[numberDepartment - 1].AddPatient(currentPatient);
    }

    public void AddDoctor(Doctor dt, int numberDepartment)
    {
        _buildings.ToList()[numberDepartment - 1].AddDoctor(dt);
    }
}