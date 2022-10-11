using System.ComponentModel.DataAnnotations;
using Healthcare.Models;
using Healthcare.Separations.Models;

namespace Healthcare.Reception.Models;

internal class Record
{
    public Record(Doctor doctor, Patient patient, DateTime time, Cabinet cabinet)
    {
        Id = new Guid();
        ResponsibleDoctor = doctor;
        RegisteredPatient = patient;
        RecordingTime = time;
        AttachedCabinet = cabinet;
    }

    public Record()
    {

    }
    [Key]
    public Guid Id { get; set; }
    public Doctor ResponsibleDoctor { get; set; }
    public Patient RegisteredPatient { get; set; }
    public DateTime RecordingTime { get; set; }
    public Cabinet AttachedCabinet { get; set; }
}