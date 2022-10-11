using System.ComponentModel.DataAnnotations;

namespace Healthcare.Models;

internal class Doctor : IPeople
{
    public Doctor(string surname, string name, string society, string adr, string diplom,
        TypeDoctor specializationDoctor, string beginWorkTime,
        string endWorkTime)
    {
        Id = new Guid();
        Surname = surname;
        Name = name;
        Society = society;
        Address = adr;
        Diplom = diplom;
        SpecializationDoctor = specializationDoctor;
        BeginWorkTime = beginWorkTime;
        EndWorkTime = endWorkTime;
    }

    public Doctor()
    {

    }

    public string Diplom { get; set; }
    public string BeginWorkTime { get; set; }
    public string EndWorkTime { get; set; }
    public TypeDoctor SpecializationDoctor { get; set; }
    [Key]
    public Guid Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Society { get; set; }

    public string FullName => Surname + " " + Name + " " + Society;

    public string Address { get; set; }
}