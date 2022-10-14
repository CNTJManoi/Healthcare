namespace Healthcare.Logic.Models;

public class Patient : IPeople
{
    public Patient(string surname, string name, string society, string address)
    {
        Id = Guid.NewGuid();
        Surname = surname;
        Name = name;
        Society = society;
        Address = address;
    }

    /// <summary>
    ///     Конструктор для базы данных
    /// </summary>
    public Patient()
    {
    }
    /// <summary>
    /// Идентификационный номер
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Фамилия доктора
    /// </summary>
    public string Surname { get; set; }
    /// <summary>
    /// Имя доктора
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Отчество доктора
    /// </summary>
    public string Society { get; set; }
    /// <summary>
    /// Фамилия, имя и отчество доктора
    /// </summary>
    public string FullName => Surname + " " + Name + " " + Society;
    /// <summary>
    /// Адрес постоянного места жительства
    /// </summary>
    public string Address { get; set; }
}