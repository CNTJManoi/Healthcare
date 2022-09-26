namespace Healthcare.Models;

internal class Patient : IPeople
{
    public Patient(string surname, string name, string society, string address)
    {
        Id = Guid.NewGuid();
        Surname = surname;
        Name = name;
        Society = society;
        Address = address;
    }

    public Guid Id { get; }

    public string Surname { get; }
    public string Name { get; }
    public string Society { get; }

    public string FullName => Surname + " " + Name + " " + Society;

    public string Address { get; }
}