using System.ComponentModel;
using Healthcare.Json;
using Healthcare.Models;
using Healthcare.Models.Separations;

namespace Healthcare.Menu;

internal class HospitalMenu
{
    private bool _isContinue;

    public HospitalMenu(Hospital? hp, string path)
    {
        Hospital = hp ?? throw new ArgumentNullException(nameof(hp));
        CurrentPatient = new Patient("Лебедев", "Артём", "Викторович", "Многоножная 12");
        OptionsMenu = new List<OptionMenu>();
        _isContinue = true;
        Hospital.ReceptionHospital.Message += PrintMessage;
        PathFile = path;
    }

    private Hospital? Hospital { get; }
    private Patient CurrentPatient { get; }
    private List<OptionMenu> OptionsMenu { get; }
    private string PathFile { get; }

    public void Start()
    {
        _isContinue = true;
        Prepare();
        while (_isContinue)
        {
            ClearScreen();
            PrintMainInfo();
            var option = ChooseOption();
            if (option > OptionsMenu.Count || option <= 0) continue;
            var t = new Task(OptionsMenu[option - 1].GetAction);
            t.Start();
            t.Wait();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    private void Prepare()
    {
        OptionsMenu.Add(new OptionMenu(() =>
            Enroll(), "Записаться к врачу"));
        OptionsMenu.Add(new OptionMenu(() =>
            Console.WriteLine(GetAllDoctors()
            ), "Посмотреть врачей больницы"));
        OptionsMenu.Add(new OptionMenu(() =>
            Console.WriteLine(Hospital.GetPatientsList()
            ), "Посмотреть пациентов больницы"));
        OptionsMenu.Add(new OptionMenu(() =>
            Console.WriteLine(Hospital.ReceptionHospital.RecordsInBook()), "Посмотреть книгу записей"));
        OptionsMenu.Add(new OptionMenu(() =>
            Console.WriteLine(Hospital.GetDepartmentsInfo()), "Информация об отделениях"));
        OptionsMenu.Add(new OptionMenu(WrtieInFile, "Записать данные о записях в файл"));

        //using (var sw = new StreamWriter(_path))
        //{
        //    sw.WriteLine("Врач " + _bookRecords.Last().ResponsibleDoctor.FullName + " у пациента " +
        //                 _bookRecords.Last().RegisteredPatient.FullName + " в "
        //                 + _bookRecords.Last().RecordingTime.Hour + ":" +
        //                 _bookRecords.Last().RecordingTime.Minute + " в кабинете номер " +
        //                 _bookRecords.Last().AttachedCabinet.Number);
        //}
        OptionsMenu.Add(new OptionMenu(() =>
            _isContinue = false, "Выйти"));
    }

    private void PrintMainInfo()
    {
        Console.WriteLine("Добро пожаловать в больницу " + Hospital.Name + "\n");
        var i = 0;
        foreach (var Option in OptionsMenu) Console.WriteLine(++i + ") " + Option.Text);
    }

    private int ChooseOption()
    {
        int option;
        while (!int.TryParse(Console.ReadLine(), out option)) Console.WriteLine("Введите корректно номер опции!");
        return option;
    }

    private int ChooseOption(int min, int max)
    {
        var valueString = "";
        int value;
        do
        {
            valueString = ChooseOption().ToString();
        } while (!int.TryParse(valueString, out value) || !(value <= max && value >= min));

        return value;
    }

    private void ClearScreen()
    {
        Console.Clear();
    }

    private void Enroll()
    {
        Console.WriteLine("Выберите отделение:");
        Console.WriteLine(Hospital.GetDepartmentsInfo());
        Console.WriteLine("\n0 для выхода в основное меню..");
        var choose = ChooseOption();
        while (!(choose <= Hospital.Building.ToList().Count() && choose >= 0)) choose = ChooseOption();
        if (choose == 0) return;
        var numberDepartment = choose;
        Console.WriteLine("Выберите врача отделения:");
        Console.WriteLine(GetDoctorsDepartmentList(choose));
        Console.WriteLine("\n0 для выхода в основное меню..");
        choose = ChooseOption();
        while (!(choose <= Hospital.Building.ToList()[numberDepartment - 1].Doctors.Count() && choose >= 0))
            choose = ChooseOption();
        if (choose == 0) return;
        var selectedDoctor = Hospital.Building.ToList()[numberDepartment - 1].Doctors.ToList()[choose - 1];
        Console.Write("Введите время (часы): ");
        var timeH = ChooseOption(0, 24);
        Console.Write("Введите время (минуты): ");
        var timeM = ChooseOption(0, 60);
        var dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeH, timeM, 0);
        var result = Hospital.ReceptionHospital.RegistrationRecord(selectedDoctor, CurrentPatient, dt,
            (IManageData)Hospital.Building.ToList()[numberDepartment - 1]);
        if (result) Hospital.AddPatient(CurrentPatient, numberDepartment);
    }

    private string GetDoctorSpecilialization(Doctor dt)
    {
        switch (dt.SpecializationDoctor)
        {
            case TypeDoctor.Therapist:
                return "Терапевт";
            case TypeDoctor.Paramedic:
                return "Фельдшер";
            case TypeDoctor.Gynecologist:
                return "Гинеколог";
            case TypeDoctor.Optometrist:
                return "Окулист";
            case TypeDoctor.Surgeon:
                return "Хирург";
            case TypeDoctor.Nurse:
                return "Медсестра/Медбрат";
            default:
                return string.Empty;
        }
    }

    public string GetDoctorsDepartmentList(int choose)
    {
        var numberDoctor = 1;
        var res = "";
        foreach (var doctor in Hospital.Building.ToList()[choose - 1].Doctors)
        {
            var spec = GetDoctorSpecilialization(doctor);

            res += numberDoctor + ". " + spec + " " + doctor.FullName + " время работы "
                   + doctor.BeginWorkTime + "-" + doctor.EndWorkTime + "\n";
            numberDoctor++;
        }


        return res;
    }

    public string GetAllDoctors()
    {
        var numberDoctor = 1;
        var res = "";
        foreach (var department in Hospital.Building.ToList())
        foreach (var doctor in department.Doctors)
        {
            var spec = GetDoctorSpecilialization(doctor);
            res += numberDoctor + ". " + spec + " " + doctor.FullName + " время работы "
                   + doctor.BeginWorkTime + "-" + doctor.EndWorkTime + "\n";
            numberDoctor++;
        }


        return res;
    }

    private void PrintMessage(object sender, EventArgs e)
    {
        Console.WriteLine((e as AddingNewEventArgs).NewObject);
    }

    private void WrtieInFile()
    {
        JsonConverter<List<Record>>.SerializeObject(Hospital.ReceptionHospital.BookRecords.ToList(), PathFile);
        Console.WriteLine("Успешно!");
    }
}