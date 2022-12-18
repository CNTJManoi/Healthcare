using Healthcare.Logic.Models;
using Healthcare.Logic.Reception.Models;
using Healthcare.Logic.Separations;

namespace Healthcare.Logic.Reception;

public class Reception
{
    private readonly List<Record> _bookRecords;
    /// <summary>
    /// Приемная больницы
    /// </summary>
    public Reception()
    {
        _bookRecords = new List<Record>();
        Id = Guid.NewGuid();
    }

    /// <summary>
    ///     Идентификационный номер
    /// </summary>
    public Guid Id { get; }

    public IEnumerable<Record> BookRecords => _bookRecords;

    /// <summary>
    ///     Осуществить запись в книгу
    /// </summary>
    /// <param name="doctor"></param>
    /// <param name="patient"></param>
    /// <param name="time"></param>
    /// <param name="department"></param>
    /// <returns></returns>
    public TypeStatus RegisterRecord(Doctor doctor, Patient patient, DateTime time, IManageData department)
    {
        var resultCheck = VerifyParametersRecord(doctor, patient, time, department);
        if (resultCheck == TypeStatus.Successfully)
        {
            var record = department.AddRecord(doctor, patient, time);
            _bookRecords.Add(record);
            return TypeStatus.Successfully;
        }

        return resultCheck;
    }

    private TypeStatus VerifyParametersRecord(Doctor doctor, Patient patient, DateTime time, IManageData department)
    {
        if (!TimeIsEnteredCorrectly(time) || !DoctorIsWorkingAtThisTime(doctor, time)) return TypeStatus.ErrorTime;
        if (EntriesInBookIsMissing(doctor, patient, time)) return TypeStatus.DoctorBusy;
        return TypeStatus.Successfully;
    }

    private bool TimeIsEnteredCorrectly(DateTime time)
    {
        if (time.Minute % 15 != 0) return false;
        return true;
    }

    private bool DoctorIsWorkingAtThisTime(Doctor doctor, DateTime time)
    {
        if (time.Hour > int.Parse(doctor.EndWorkTime) || time.Hour < int.Parse(doctor.BeginWorkTime))
            return false;
        return true;
    }

    private bool EntriesInBookIsMissing(Doctor doctor, Patient patient, DateTime time)
    {
        if (!_bookRecords.Any(x => x.ResponsibleDoctor ==
                doctor && x.RegisteredPatient == patient)
            && !_bookRecords.Any(x => x.ResponsibleDoctor ==
                doctor && x.RecordingTime.Hour == time.Hour && x.RecordingTime.Minute == time.Minute))
            return false;

        return true;
    }

    /// <summary>
    ///     Внести уже существующую запись
    /// </summary>
    /// <param name="record"></param>
    public void RegisterRecord(Record record)
    {
        _bookRecords.Add(record);
    }
}