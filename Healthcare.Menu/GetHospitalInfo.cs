using Healthcare.Logic;
using Healthcare.Logic.Models;

namespace Healthcare.Menu;

internal class GetHospitalInfo
{
    public GetHospitalInfo(Hospital hp)
    {
        Hospital = hp;
    }

    private Hospital Hospital { get; }

    public string GetPatientsList()
    {
        var numberPatient = 1;
        var res = "";
        foreach (var department in Hospital.Buildings)
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
        foreach (var department in Hospital.Buildings)
            res += department.Name + " по адресу " + department.Address + "\n";

        return res;
    }


    public string RecordsInBook()
    {
        var str = "";
        foreach (var record in Hospital.ReceptionHospital.BookRecords)
            str += "Врач " + record.ResponsibleDoctor.FullName + " у пациента " +
                   record.RegisteredPatient.FullName + " в "
                   + record.RecordingTime.Hour + ":" +
                   record.RecordingTime.Minute + " в кабинете номер " +
                   record.AttachedCabinet.Number + "\n";
        return str;
    }


    public string GetDoctorSpecilialization(Doctor dt)
    {
        return dt.SpecializationDoctor switch
        {
            TypeDoctor.Therapist => "Терапевт",
            TypeDoctor.Paramedic => "Фельдшер",
            TypeDoctor.Gynecologist => "Гинеколог",
            TypeDoctor.Optometrist => "Окулист",
            TypeDoctor.Surgeon => "Хирург",
            TypeDoctor.Nurse => "Медсестра/Медбрат",
            _ => string.Empty
        };
    }

    public string GetDoctorsDepartmentList(int choose)
    {
        var numberDoctor = 1;
        var res = "";
        foreach (var doctor in Hospital.Buildings.ToList()[choose - 1].Doctors)
        {
            var spec = GetDoctorSpecilialization(doctor);

            res += numberDoctor + ". " + spec + " " + doctor.FullName + " время работы "
                   + doctor.BeginWorkTime + "-" + doctor.EndWorkTime + "\n";
            numberDoctor++;
        }


        return res;
    }

    public string GetAllDoctors()
    {
        var numberDoctor = 1;
        var res = "";
        foreach (var department in Hospital.Buildings.ToList())
        foreach (var doctor in department.Doctors)
        {
            var spec = GetDoctorSpecilialization(doctor);
            res += numberDoctor + ". " + spec + " " + doctor.FullName + " время работы "
                   + doctor.BeginWorkTime + "-" + doctor.EndWorkTime + "\n";
            numberDoctor++;
        }


        return res;
    }
}