using Healthcare.Logic.Models;
using Healthcare.Logic.Separations.Base;

namespace Healthcare.Logic;

public class Hospital
{
    private readonly List<IDepartment> _buildings;

    public Hospital(Guid id, string name)
    {
        Id = id;
        Name = name;
        ReceptionHospital = new Reception.Reception();
        _buildings = new List<IDepartment>();
    }

    /// <summary>
    ///     Приемная больницы
    /// </summary>
    public Reception.Reception ReceptionHospital { get; }

    /// <summary>
    ///     Перечисляемый список отделений в больнице
    /// </summary>
    public IEnumerable<IDepartment> Buildings => _buildings;

    public Guid Id { get; }

    /// <summary>
    ///     Наименование больницы
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Добавить отделение в больницу
    /// </summary>
    /// <param name="department">ЭЭкземпляр класса отделения</param>
    public void AddDepartment(IDepartment department)
    {
        _buildings.Add(department);
    }

    /// <summary>
    ///     Добавить пациента в определенное отделение больницы
    /// </summary>
    /// <param name="currentPatient">Экземпляр класса пациента</param>
    /// <param name="numberDepartment">Номер отделения больницы</param>
    public void AddPatient(Patient currentPatient, int numberDepartment)
    {
        _buildings[numberDepartment - 1].AddPatient(currentPatient);
    }

    /// <summary>
    ///     Добавить доктора в определенное отделение больницы
    /// </summary>
    /// <param name="dt">Экземпляр класса доктора</param>
    /// <param name="numberDepartment">Номер отделения больницы</param>
    public void AddDoctor(Doctor dt, int numberDepartment)
    {
        _buildings[numberDepartment - 1].AddDoctor(dt);
    }
}