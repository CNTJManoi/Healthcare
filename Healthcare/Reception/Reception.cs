using Healthcare.Logic.Models;
using Healthcare.Logic.Reception.Models;
using Healthcare.Logic.Separations;

namespace Healthcare.Logic.Reception;

public class Reception
{
    private readonly List<Record> _bookRecords;

    public Reception()
    {
        _bookRecords = new List<Record>();
        Id = Guid.NewGuid();
    }

    /// <summary>
    ///     Идентификационный номер
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Исчисляемый список записей к врачам
    /// </summary>
    public IEnumerable<Record> BookRecords => _bookRecords;

    /// <summary>
    ///     Осуществить запись в книгу
    /// </summary>
    /// <param name="doctor">Экземпляр класса доктора</param>
    /// <param name="patient">Экземпляр класса пациент</param>
    /// <param name="time">Время записи</param>
    /// <param name="department">Отделение</param>
    /// <returns>Статус заявки</returns>
    public TypeStatus RegistrationRecord(Doctor doctor, Patient patient, DateTime time, IManageData department)
    {
        var resultCheck = CheckParametersRecord(doctor, patient, time, department);
        if (resultCheck == TypeStatus.Successfully)
        {
            var record = department.AddRecord(doctor, patient, time);
            if (record != null)
            {
                _bookRecords.Add(record);
                return TypeStatus.Successfully;
            }

            return TypeStatus.OfficesBusy;
        }

        return resultCheck;
    }

    private TypeStatus CheckParametersRecord(Doctor doctor, Patient patient, DateTime time, IManageData department)
    {
        if (!TestTime(time) || !CheckTimeDoctor(doctor, time)) return TypeStatus.ErrorTime;
        if (CheckRecordInBook(doctor, patient, time)) return TypeStatus.DoctorBusy;
        return TypeStatus.Successfully;
    }

    private bool TestTime(DateTime time)
    {
        if (time.Minute % 15 != 0) return false;
        return true;
    }

    private bool CheckTimeDoctor(Doctor doctor, DateTime time)
    {
        if (time.Hour > int.Parse(doctor.EndWorkTime) || time.Hour < int.Parse(doctor.BeginWorkTime))
            return false;
        return true;
    }

    private bool CheckRecordInBook(Doctor doctor, Patient patient, DateTime time)
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
    /// <param name="record">Экземпляр класса записи</param>
    public void RegistrationRecord(Record record)
    {
        _bookRecords.Add(record);
    }
}