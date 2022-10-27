namespace Healthcare.Logic.Models;

public class Patient : IPeople
{
    public Patient(string surname, string name, string society, string address, Guid id)
    {
        Id = id;
        Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Society = society ?? throw new ArgumentNullException(nameof(society));
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    /// <summary>
    ///     Идентификационный номер
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Фамилия доктора
    /// </summary>
    public string Surname { get; }

    /// <summary>
    ///     Имя доктора
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Отчество доктора
    /// </summary>
    public string Society { get; }

    /// <summary>
    ///     Фамилия, имя и отчество доктора
    /// </summary>
    public string FullName => Surname + " " + Name + " " + Society;

    /// <summary>
    ///     Адрес постоянного места жительства
    /// </summary>
    public string Address { get; set; }
}