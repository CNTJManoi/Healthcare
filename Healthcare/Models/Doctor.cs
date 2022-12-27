namespace Healthcare.Logic.Models;

public class Doctor : IPeople
{
    public Doctor(string surname, string name, string patronymic, string address, string diplom,
        TypeDoctor specializationDoctor, string beginWorkTime,
        string endWorkTime)
    {
        Id = new Guid();
        Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Diplom = diplom ?? throw new ArgumentNullException(nameof(diplom));
        SpecializationDoctor = specializationDoctor;
        BeginWorkTime = beginWorkTime ?? throw new ArgumentNullException(nameof(beginWorkTime));
        EndWorkTime = endWorkTime ?? throw new ArgumentNullException(nameof(endWorkTime));
    }

    /// <summary>
    ///     Серия и номер документа об образовании
    /// </summary>
    public string Diplom { get; }

    /// <summary>
    ///     Время начала рабочего дня
    /// </summary>
    public string BeginWorkTime { get; }

    /// <summary>
    ///     Время окончания рабочего дня
    /// </summary>
    public string EndWorkTime { get; }

    /// <summary>
    ///     Специализация
    /// </summary>
    public TypeDoctor SpecializationDoctor { get; }

    /// <summary>
    ///     Идентификационный номер
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Фамилия
    /// </summary>
    public string Surname { get; }

    /// <summary>
    ///     Имя
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Отчество
    /// </summary>
    public string Patronymic { get; }

    /// <summary>
    ///     Фамилия, имя и отчество
    /// </summary>
    public string FullName => Surname + " " + Name + " " + Patronymic;

    /// <summary>
    ///     Адрес постоянного места жительства
    /// </summary>
    public string Address { get; }
}