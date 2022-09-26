using System.ComponentModel;
using Healthcare.Models;
using Healthcare.Models.Separations;

namespace Healthcare;

internal class Reception
{
    private readonly List<Record> _bookRecords;
    private readonly string _path;

    public Reception()
    {
        _bookRecords = new List<Record>();
        _path = Environment.CurrentDirectory + @"\info.data";
    }

    public int Id { get; set; }
    public IEnumerable<Record> BookRecords => _bookRecords;
    public event EventHandler Message;

    public bool RegistrationRecord(Doctor doctor, Patient patient, DateTime time, IDataDepartment department)
    {
        if (time.Minute % 15 != 0)
        {
            ThrowNewError("Можно записаться лишь на 0, 15, 30, 45 минуты часа...");
            return false;
        }

        if (time.Hour > int.Parse(doctor.EndWorkTime) || time.Hour < int.Parse(doctor.BeginWorkTime))
        {
            ThrowNewError("Выбрано не рабочее время врача!");
            return false;
        }

        if (_bookRecords.Where(x => x.ResponsibleDoctor == doctor && x.RegisteredPatient == patient).Count() ==
            0
            || _bookRecords.Where(x => x.ResponsibleDoctor == doctor && x.RecordingTime == time).Count() == 0)
        {
            foreach (var cabinet in department.Cabinets)
                if (cabinet.TypeDoctor == doctor.SpecializationDoctor && !cabinet.CabinetIsBusy(doctor))
                {
                    _bookRecords.Add(new Record(doctor, patient, time, cabinet));
                    ThrowNewError("Запись создана!");
                    using (var sw = new StreamWriter(_path))
                    {
                        sw.WriteLine("Врач " + _bookRecords.Last().ResponsibleDoctor.FullName + " у пациента " +
                                     _bookRecords.Last().RegisteredPatient.FullName + " в "
                                     + _bookRecords.Last().RecordingTime.Hour + ":" +
                                     _bookRecords.Last().RecordingTime.Minute + " в кабинете номер " +
                                     _bookRecords.Last().AttachedCabinet.Number);
                    }

                    return true;
                }
        }
        else
        {
            ThrowNewError("Выберите другое время!");
            return false;
        }

        ThrowNewError("Все кабинеты заняты!");
        return false;
    }

    public string RecordsInBook()
    {
        var str = "";
        foreach (var record in _bookRecords) str += "Врач " + record.ResponsibleDoctor.FullName + " у пациента " +
                                                    record.RegisteredPatient.FullName + " в "
                                                    + record.RecordingTime.Hour + ":" +
                                                    record.RecordingTime.Minute + " в кабинете номер " +
                                                    record.AttachedCabinet.Number + "\n";
        return str;
    }

    private void ThrowNewError(string text)
    {
        if (Message != null) Message.Invoke(this, new AddingNewEventArgs(text));
    }
}