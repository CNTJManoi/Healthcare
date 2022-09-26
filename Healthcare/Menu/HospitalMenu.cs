using System.ComponentModel;
using Healthcare.Models;

namespace Healthcare.Menu;

internal class HospitalMenu
{
    private bool _isContinue;

    public HospitalMenu(Hospital? hp)
    {
        Hospital = hp ?? throw new ArgumentNullException(nameof(hp));
        CurrentPatient = new Patient("Лебедев", "Артём", "Викторович", "Многоножная 12");
        OptionsMenu = new List<OptionMenu>();
        _isContinue = true;
        Hospital.ReceptionHospital.Message += PrintMessage;
    }

    private Hospital? Hospital { get; }
    private Patient CurrentPatient { get; }
    private List<OptionMenu> OptionsMenu { get; }

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
            Enroll()));
        OptionsMenu.Add(new OptionMenu(() =>
            Console.WriteLine(GetAllDoctors()
            )));
        OptionsMenu.Add(new OptionMenu(() =>
            Console.WriteLine(Hospital.GetPatientsList()
            )));
        OptionsMenu.Add(new OptionMenu(() =>
            Console.WriteLine(Hospital.ReceptionHospital.RecordsInBook())));
        OptionsMenu.Add(new OptionMenu(() =>
            Console.WriteLine(Hospital.GetDepartmentsInfo())));
        OptionsMenu.Add(new OptionMenu(() =>
            _isContinue = false));
    }

    private void PrintMainInfo()
    {
        Console.WriteLine("Добро пожаловать в больницу " + Hospital.Name + "\n" +
                          "Выберите опцию..." + "\n" +
                          "1 - Записаться к врачу" + "\n" +
                          "2 - Посмотреть врачей больницы" + "\n" +
                          "3 - Посмотреть пациентов больницы" + "\n" +
                          "4 - Посмотреть книгу записей" + "\n" +
                          "5 - Информацию об отделениях" + "\n" +
                          "6 - Выйти");
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
            Hospital.Building.ToList()[numberDepartment - 1]);
        if (result)
        {
            Hospital.AddPatient(CurrentPatient, numberDepartment);
            Hospital.TakeCabinet(numberDepartment, Hospital.ReceptionHospital.BookRecords.Last().AttachedCabinet,
                selectedDoctor);
        }
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
}