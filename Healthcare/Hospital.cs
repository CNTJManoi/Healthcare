using Healthcare.Logic.Models;
using Healthcare.Logic.Separations.Base;

namespace Healthcare.Logic;

public class Hospital
{
    private readonly List<IDepartment> _buildings;
    /// <summary>
    /// Больница
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public Hospital(Guid id, string name)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        ReceptionHospital = new Reception.Reception();
        _buildings = new List<IDepartment>();
    }

    /// <summary>
    ///     Приемная больницы
    /// </summary>
    public Reception.Reception ReceptionHospital { get; }

    public IEnumerable<IDepartment> Buildings => _buildings;

    public Guid Id { get; }

    /// <summary>
    ///     Наименование
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Добавить отделение
    /// </summary>
    /// <param name="department"></param>
    public void AddDepartment(IDepartment department)
    {
        _buildings.Add(department);
    }

    /// <summary>
    ///     Добавить пациента в определенное отделение
    /// </summary>
    /// <param name="currentPatient"></param>
    /// <param name="numberDepartment">Номер отделения</param>
    public void AddPatient(Patient currentPatient, int numberDepartment)
    {
        _buildings[numberDepartment - 1].AddPatient(currentPatient);
    }

    /// <summary>
    ///     Добавить доктора в определенное отделение
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="numberDepartment">Номер отделения</param>
    public void AddDoctor(Doctor dt, int numberDepartment)
    {
        _buildings[numberDepartment - 1].AddDoctor(dt);
    }
}