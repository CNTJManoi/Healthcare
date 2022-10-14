namespace Healthcare.Models;

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

    public Guid Id { get; set; }

    public string Surname { get; set; }
    public string Name { get; set; }
    public string Society { get; set; }

    public string FullName => Surname + " " + Name + " " + Society;

    public string Address { get; set; }
}