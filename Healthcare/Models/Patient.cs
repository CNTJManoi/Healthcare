namespace Healthcare.Logic.Models;

public class Patient : IPeople
{
    public Patient(string surname, string name, string Patronymic, string address, Guid id)
    {
        Id = id;
        Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Patronymic = Patronymic ?? throw new ArgumentNullException(nameof(Patronymic));
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

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
    public string Address { get; set; }
}