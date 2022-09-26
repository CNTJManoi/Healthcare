using Healthcare.Models;
using Healthcare.Models.Separations;

namespace Healthcare;

internal enum TypeDoctor
{
    Therapist,
    Paramedic,
    Gynecologist,
    Optometrist,
    Surgeon,
    Nurse
}

internal class Hospital
{
    private readonly List<IDataDepartment> _buildings;

    public Hospital(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        ReceptionHospital = new Reception();
        _buildings = new List<IDataDepartment>();
    }

    public IEnumerable<IDataDepartment> Building => _buildings;
    public Reception ReceptionHospital { get; }

    public Guid Id { get; }

    public string Name { get; set; }


    public string GetPatientsList()
    {
        var numberPatient = 1;
        var res = "";
        foreach (var department in _buildings)
        foreach (var patient in department.Patients)
        {
            res += numberPatient + ". " + patient.FullName + " " + patient.Address + "\n";
            numberPatient++;
        }

        return res;
    }

    public string GetDepartmentsInfo()
    {
        var res = "";
        foreach (var department in _buildings) res += department.Name + " по адресу " + department.Address + "\n";

        return res;
    }

    public void AddDepartment(IDataDepartment department)
    {
        _buildings.Add(department);
    }

    public void AddDoctor(Doctor dt, int numberDepartment)
    {
        if (numberDepartment > _buildings.Count || numberDepartment < 0) throw new ArgumentOutOfRangeException();
        (_buildings[numberDepartment] as IManageData).AddDoctor(dt);
    }

    public void AddPatient(Patient dt, int numberDepartment)
    {
        if (numberDepartment > _buildings.Count || numberDepartment < 0) throw new ArgumentOutOfRangeException();
        (_buildings[numberDepartment - 1] as IManageData).AddPatient(dt);
    }

    public void TakeCabinet(int numberDepartment, Cabinet cb, Doctor dt)
    {
        _buildings[numberDepartment - 1].Cabinets[_buildings[numberDepartment - 1]
                .Cabinets.IndexOf(cb)]
            .EnterCabient(dt);
    }
}