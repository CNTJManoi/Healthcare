using Healthcare.Logic.Models;
using Healthcare.Logic.Separations;
using Healthcare.Logic.Separations.Models;

namespace Healthcare.Logic.Reception.Models;

public class Record
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
    /// <summary>
    /// Идентификационный номер записи
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Отвественный доктор
    /// </summary>
    public Doctor ResponsibleDoctor { get; set; }
    /// <summary>
    /// Прикрепленный пациент
    /// </summary>
    public Patient RegisteredPatient { get; set; }
    /// <summary>
    /// Время записи
    /// </summary>
    public DateTime RecordingTime { get; set; }
    /// <summary>
    /// Прикрепленный кабинет
    /// </summary>
    public Cabinet AttachedCabinet { get; set; }
    /// <summary>
    /// Отвественное отделение
    /// </summary>
    public Department AttachedDepartment { get; set; }
}