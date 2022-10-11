using System.ComponentModel.DataAnnotations;

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

    public Patient()
    {

    }
    [Key]
    public Guid Id { get; set; }

    public string Surname { get; set; }
    public string Name { get; set; }
    public string Society { get; set; }

    public string FullName => Surname + " " + Name + " " + Society;

    public string Address { get; set; }
}