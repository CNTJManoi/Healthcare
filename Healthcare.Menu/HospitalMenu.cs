using Healthcare.Database;
using Healthcare.Json;
using Healthcare.Logic;
using Healthcare.Logic.Models;
using Healthcare.Logic.Reception.Models;
using Healthcare.Notification;

namespace Healthcare.Menu;

internal class HospitalMenu
{
    private bool _isContinue;

    public HospitalMenu(Hospital? hp, DatabaseManager? dm = null)
    {
        Hospital = hp ?? throw new ArgumentNullException(nameof(hp));
        CurrentPatient = new Patient("Лебедев", "Артём", "Викторович", "Многоножная 12", Guid.NewGuid());
        OptionsMenu = new List<OptionMenu>();
        HospitalInfo = new GetHospitalInfo(hp);
        DatabaseManager = dm;
        _isContinue = true;
        Annunciator = new Annunciator();
    }

    private Hospital? Hospital { get; }
    private Patient CurrentPatient { get; }
    private List<OptionMenu> OptionsMenu { get; }
    private GetHospitalInfo HospitalInfo { get; }
    private DatabaseManager? DatabaseManager { get; }
    private Annunciator Annunciator { get; }
    private string PathFile { get; }

    /// <summary>
    ///     Начало работы консольного меню
    /// </summary>
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
            PrintMessage("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    private void Prepare()
    {
        OptionsMenu.Add(new OptionMenu(() =>
            Enroll(), "Записаться к врачу"));
        OptionsMenu.Add(new OptionMenu(() =>
            PrintMessage(GetAllDoctors()
            ), "Посмотреть врачей больницы"));
        OptionsMenu.Add(new OptionMenu(() =>
            PrintMessage(HospitalInfo.GetPatientsList()
            ), "Посмотреть пациентов больницы"));
        OptionsMenu.Add(new OptionMenu(() =>
            PrintMessage(HospitalInfo.RecordsInBook()), "Посмотреть книгу записей"));
        OptionsMenu.Add(new OptionMenu(() =>
            PrintMessage(HospitalInfo.GetDepartmentsInfo()), "Информация об отделениях"));
        OptionsMenu.Add(new OptionMenu(WriteInFile, "Записать данные о записях в файл"));
        OptionsMenu.Add(new OptionMenu(() =>
            _isContinue = false, "Выйти"));
    }

    private void PrintMainInfo()
    {
        PrintMessage("Добро пожаловать в больницу " + Hospital.Name + "\n");
        var i = 0;
        foreach (var Option in OptionsMenu) PrintMessage(++i + ") " + Option.Text);
    }

    private int ChooseOption()
    {
        int option;
        while (!int.TryParse(Console.ReadLine(), out option)) PrintMessage("Введите корректно номер опции!");
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
        PrintMessage("Выберите отделение:");
        PrintMessage(HospitalInfo.GetDepartmentsInfo());
        PrintMessage("\n0 для выхода в основное меню..");
        var choose = ChooseOption();
        while (!(choose <= Hospital.Buildings.ToList().Count() && choose >= 0)) choose = ChooseOption();
        if (choose == 0) return;
        var numberDepartment = choose;
        PrintMessage("Выберите врача отделения:");
        PrintMessage(GetDoctorsDepartmentList(choose));
        PrintMessage("\n0 для выхода в основное меню..");
        choose = ChooseOption();
        while (!(choose <= Hospital.Buildings.ToList()[numberDepartment - 1].Doctors.Count() && choose >= 0))
            choose = ChooseOption();
        if (choose == 0) return;
        var selectedDoctor = Hospital.Buildings.ToList()[numberDepartment - 1].Doctors.ToList()[choose - 1];
        PrintMessage("Введите время (часы): ");
        var timeH = ChooseOption(0, 24);
        PrintMessage("Введите время (минуты): ");
        var timeM = ChooseOption(0, 60);
        var dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeH, timeM, 0);
        var result = Hospital.ReceptionHospital.RegistrationRecord(selectedDoctor, CurrentPatient, dt,
            Hospital.Buildings.ToList()[numberDepartment - 1]);
        switch (result)
        {
            case TypeStatus.Successfully:
                Hospital.AddPatient(CurrentPatient, numberDepartment);
                if (DatabaseManager != null) DatabaseManager.SaveRecord(Hospital.ReceptionHospital.BookRecords.Last());
                PrintMessage("Запись создана!");
                break;
            case TypeStatus.DoctorBusy:
                PrintMessage("Выбрано не рабочее время врача!");
                break;
            case TypeStatus.ErrorTime:
                PrintMessage("Можно записаться лишь на 0, 15, 30, 45 минуты часа...");
                break;
            case TypeStatus.GeneralError:
                PrintMessage("Выберите другое время!");
                break;
            case TypeStatus.OfficesBusy:
                PrintMessage("Все кабинеты заняты!");
                break;
            default:
                PrintMessage("Попробуйте еще раз!");
                break;
        }
    }

    private string GetDoctorSpecilialization(Doctor dt)
    {
        return dt.SpecializationDoctor switch
        {
            TypeDoctor.Therapist => "Терапевт",
            TypeDoctor.Paramedic => "Фельдшер",
            TypeDoctor.Gynecologist => "Гинеколог",
            TypeDoctor.Optometrist => "Окулист",
            TypeDoctor.Surgeon => "Хирург",
            TypeDoctor.Nurse => "Медсестра/Медбрат",
            _ => string.Empty
        };
    }

    private string GetDoctorsDepartmentList(int choose)
    {
        var numberDoctor = 1;
        var res = "";
        foreach (var doctor in Hospital.Buildings.ToList()[choose - 1].Doctors)
        {
            var spec = GetDoctorSpecilialization(doctor);

            res += numberDoctor + ". " + spec + " " + doctor.FullName + " время работы "
                   + doctor.BeginWorkTime + "-" + doctor.EndWorkTime + "\n";
            numberDoctor++;
        }


        return res;
    }

    private string GetAllDoctors()
    {
        var numberDoctor = 1;
        var res = "";
        foreach (var department in Hospital.Buildings.ToList())
        foreach (var doctor in department.Doctors)
        {
            var spec = GetDoctorSpecilialization(doctor);
            res += numberDoctor + ". " + spec + " " + doctor.FullName + " время работы "
                   + doctor.BeginWorkTime + "-" + doctor.EndWorkTime + "\n";
            numberDoctor++;
        }


        return res;
    }

    private void PrintMessage(string text)
    {
        Console.WriteLine(text);
    }

    private void WriteInFile()
    {
        Annunciator.Notify(JsonConverter<List<Record>>.SerializeObject(Hospital.ReceptionHospital.BookRecords.ToList()),
            TypeNotification.File);
        PrintMessage("Успешно!");
    }
}