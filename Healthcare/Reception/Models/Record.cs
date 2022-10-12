using Healthcare.Models;
using Healthcare.Separations;
using Healthcare.Separations.Models;

namespace Healthcare.Reception.Models;

internal class Record
{
    public Record(Doctor doctor, Patient patient, DateTime time, Cabinet cabinet, Department department)
    {
        Id = new Guid();
        ResponsibleDoctor = doctor;
        RegisteredPatient = patient;
        RecordingTime = time;
        AttachedCabinet = cabinet;
        AttachedDepartment = department;
    }

    /// <summary>
    ///     Конструктор для базы данных
    /// </summary>
    public Record()
    {
    }

    public Guid Id { get; set; }
    public Doctor ResponsibleDoctor { get; set; }
    public Patient RegisteredPatient { get; set; }
    public DateTime RecordingTime { get; set; }
    public Cabinet AttachedCabinet { get; set; }
    public Department AttachedDepartment { get; set; }
}