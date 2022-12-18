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
    /// <summary>
    /// Модель записи определенного пациента к доктору в установленное время
    /// </summary>
    /// <param name="recordingTime"></param>
    /// <param name="id"></param>
    /// <param name="attachedCabinet"></param>
    /// <param name="responsibleDoctor"></param>
    /// <param name="registeredPatient"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public Record(DateTime recordingTime, Guid id,
        Cabinet attachedCabinet, Doctor responsibleDoctor, Patient registeredPatient) : this(recordingTime, id)
    {
        AttachedCabinet = attachedCabinet ?? throw new ArgumentNullException(nameof(attachedCabinet));
        ResponsibleDoctor = responsibleDoctor ?? throw new ArgumentNullException(nameof(responsibleDoctor));
        RegisteredPatient = registeredPatient ?? throw new ArgumentNullException(nameof(registeredPatient));
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