using Healthcare.Logic.Models;
using Healthcare.Logic.Separations.Models;

namespace Healthcare.Logic.Reception.Models;

public class Record
{
    private Record(DateTime recordingTime, Guid id)
    {
        Id = id;
        RecordingTime = recordingTime;
    }

    public Record(DateTime recordingTime, Guid id,
        Cabinet attachedCabinet, Doctor responsibleDoctor, Patient registeredPatient) : this(recordingTime, id)
    {
        AttachedCabinet = attachedCabinet;
        ResponsibleDoctor = responsibleDoctor;
        RegisteredPatient = registeredPatient;
    }

    /// <summary>
    ///     Идентификационный номер записи
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Отвественный доктор
    /// </summary>
    public Doctor ResponsibleDoctor { get; }

    /// <summary>
    ///     Прикрепленный пациент
    /// </summary>
    public Patient RegisteredPatient { get; }

    /// <summary>
    ///     Время записи
    /// </summary>
    public DateTime RecordingTime { get; }

    /// <summary>
    ///     Прикрепленный кабинет
    /// </summary>
    public Cabinet AttachedCabinet { get; }
}