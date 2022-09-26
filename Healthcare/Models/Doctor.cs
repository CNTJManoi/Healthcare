namespace Healthcare.Models;

internal class Doctor : IPeople
{
    public Doctor(string surname, string name, string society, string adr, string diplom,
        TypeDoctor specializationDoctor, string beginWorkTime,
        string endWorkTime)
    {
        Id = Guid.NewGuid();
        Surname = surname;
        Name = name;
        Society = society;
        Address = adr;
        Diplom = diplom;
        SpecializationDoctor = specializationDoctor;
        BeginWorkTime = beginWorkTime;
        EndWorkTime = endWorkTime;
    }

    public string Diplom { get; }
    public string BeginWorkTime { get; set; }
    public string EndWorkTime { get; set; }
    public TypeDoctor SpecializationDoctor { get; }
    public Guid Id { get; }
    public string Surname { get; }
    public string Name { get; }
    public string Society { get; }

    public string FullName => Surname + " " + Name + " " + Society;

    public string Address { get; }
}