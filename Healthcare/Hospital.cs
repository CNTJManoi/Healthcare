using Healthcare.Models;
using Healthcare.Separations.Base;

namespace Healthcare;

public class Hospital
{
    private readonly List<IDepartment> _buildings;

    public Hospital(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        ReceptionHospital = new Reception.Reception();
        _buildings = new List<IDepartment>();
    }

    /// <summary>
    ///     Конструктор для базы данных
    /// </summary>
    public Hospital()
    {
        ReceptionHospital = new Reception.Reception();
        _buildings = new List<IDepartment>();
    }

    public Reception.Reception ReceptionHospital { get; }
    public IEnumerable<IDepartment> Buildings => _buildings;
    public Guid Id { get; set; }

    public string Name { get; set; }

    public void AddDepartment(IDepartment department)
    {
        _buildings.Add(department);
    }

    public void AddPatient(Patient currentPatient, int numberDepartment)
    {
        _buildings[numberDepartment - 1].AddPatient(currentPatient);
    }

    public void AddDoctor(Doctor dt, int numberDepartment)
    {
        _buildings[numberDepartment - 1].AddDoctor(dt);
    }
}