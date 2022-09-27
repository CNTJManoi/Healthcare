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

    public bool RegistrationRecord(Doctor doctor, Patient patient, DateTime time, IManageData department)
    {
        if (time.Minute % 15 != 0)
        {
            PrintMessage("Можно записаться лишь на 0, 15, 30, 45 минуты часа...");
            return false;
        }

        if (time.Hour > int.Parse(doctor.EndWorkTime) || time.Hour < int.Parse(doctor.BeginWorkTime))
        {
            PrintMessage("Выбрано не рабочее время врача!");
            return false;
        }

        if (_bookRecords.Where(x => x.ResponsibleDoctor == doctor && x.RegisteredPatient == patient).Count() ==
            0
            || _bookRecords.Where(x => x.ResponsibleDoctor == doctor && x.RecordingTime == time).Count() == 0)
        {
            var record = department.AddRecord(doctor, patient, time);
            if (record != null)
            {
                _bookRecords.Add(record);
                PrintMessage("Запись создана!");
                return true;
            }

            PrintMessage("Все кабинеты заняты!");
            return false;
        }

        PrintMessage("Выберите другое время!");
        return false;
    }

    public string RecordsInBook()
    {
        var str = "";
        foreach (var record in _bookRecords)
            str += "Врач " + record.ResponsibleDoctor.FullName + " у пациента " +
                   record.RegisteredPatient.FullName + " в "
                   + record.RecordingTime.Hour + ":" +
                   record.RecordingTime.Minute + " в кабинете номер " +
                   record.AttachedCabinet.Number + "\n";
        return str;
    }

    private void PrintMessage(string text)
    {
        if (Message != null) Message.Invoke(this, new AddingNewEventArgs(text));
    }
}