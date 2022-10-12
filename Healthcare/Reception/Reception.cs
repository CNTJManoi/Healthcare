using Healthcare.Models;
using Healthcare.Reception.Models;
using Healthcare.Separations;

namespace Healthcare.Reception;

internal class Reception
{
    private readonly List<Record> _bookRecords;

    public Reception()
    {
        _bookRecords = new List<Record>();
    }

    public int Id { get; set; }
    public IEnumerable<Record> BookRecords => _bookRecords;

    public TypeStatus RegistrationRecord(Doctor doctor, Patient patient, DateTime time, IManageData department)
    {
        if (time.Minute % 15 != 0) return TypeStatus.ErrorTime;

        if (time.Hour > int.Parse(doctor.EndWorkTime) || time.Hour < int.Parse(doctor.BeginWorkTime))
            return TypeStatus.DoctorBusy;

        if (_bookRecords.Where(x => x.ResponsibleDoctor ==
                doctor && x.RegisteredPatient == patient).Count() == 0
            || _bookRecords.Where(x => x.ResponsibleDoctor ==
                doctor && x.RecordingTime == time).Count() == 0)
        {
            var record = department.AddRecord(doctor, patient, time);
            if (record != null)
            {
                _bookRecords.Add(record);
                return TypeStatus.Successfully;
            }

            return TypeStatus.OfficesBusy;
        }

        return TypeStatus.GeneralError;
    }

    public TypeStatus RegistrationRecord(Record record)
    {
        _bookRecords.Add(record);
        return TypeStatus.Successfully;
    }
}