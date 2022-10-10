using Healthcare.Models;
using Healthcare.Separations.Models;

namespace Healthcare.Reception.Models;

internal class Record
{
    public Record(Doctor doctor, Patient patient, DateTime time, Cabinet cabinet)
    {
        ResponsibleDoctor = doctor;
        RegisteredPatient = patient;
        RecordingTime = time;
        AttachedCabinet = cabinet;
    }

    public Doctor ResponsibleDoctor { get; }
    public Patient RegisteredPatient { get; }
    public DateTime RecordingTime { get; }
    public Cabinet AttachedCabinet { get; }
}