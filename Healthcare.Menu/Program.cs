using Healthcare.Database;
using Healthcare.Json;
using Healthcare.Logic;
using Healthcare.Notification;

namespace Healthcare.Menu;

internal class Program
{
    private static void Main(string[] args)
    {
        FileData.FileResultPath = args[1];
        Console.WriteLine("Подключение к базе данных...");
        var dm = new DatabaseManager();
        var hp = dm.LoadDatabase();
        if (hp == null)
        {
            Console.WriteLine("Попытка подключения к JSON...");
            CheckArgs(args, 2);
            Thread.Sleep(1500);
            hp = ParseFile(args[0]);
            if (hp == null)
            {
                Console.WriteLine("Произошла ошибка подключения к JSON");
                ExitProgram();
            }
            else
            {
                new HospitalMenu(hp).Start();
            }
        }
        else
        {
            new HospitalMenu(hp, dm).Start();
        }

        //Annunciator an = new Annunciator();
        //var hp = new Hospital(Guid.NewGuid(), "Яркое солнышко");
        //var cb1 = new List<Cabinet>();
        //cb1.Add(new Cabinet(TypeDoctor.Paramedic, 101, null, null, Guid.NewGuid()));
        //cb1.Add(new Cabinet(TypeDoctor.Therapist, 102, null, null, Guid.NewGuid()));
        //cb1.Add(new Cabinet(TypeDoctor.Therapist, 103, null, null, Guid.NewGuid()));
        //cb1.Add(new Cabinet(TypeDoctor.Nurse, 104, null, null, Guid.NewGuid()));
        //var cb2 = new List<Cabinet>();
        //cb2.Add(new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid()));
        //cb2.Add(new Cabinet(TypeDoctor.Surgeon, 102, null, null, Guid.NewGuid()));
        //cb2.Add(new Cabinet(TypeDoctor.Nurse, 103, null, null, Guid.NewGuid()));
        //cb2.Add(new Cabinet(TypeDoctor.Surgeon, 104, null, null, Guid.NewGuid()));
        //var cb3 = new List<Cabinet>();
        //cb3.Add(new Cabinet(TypeDoctor.Therapist, 101, null, null, Guid.NewGuid()));
        //cb3.Add(new Cabinet(TypeDoctor.Therapist, 102, null, null, Guid.NewGuid()));
        //cb3.Add(new Cabinet(TypeDoctor.Gynecologist, 103, null, null, Guid.NewGuid()));
        //cb3.Add(new Cabinet(TypeDoctor.Optometrist, 104, null, null, Guid.NewGuid()));
        //cb3.Add(new Cabinet(TypeDoctor.Nurse, 105, null, null, Guid.NewGuid()));
        //cb3.Add(new Cabinet(TypeDoctor.Therapist, 106, null, null, Guid.NewGuid()));
        //List<Doctor> d1 = new List<Doctor>();
        //var dd1 = new Doctor("Потапов", "Алексей", "Даниилович", "Светлая 12"
        //    , "654767", TypeDoctor.Paramedic, "09", "15");
        //var dd2 = new Doctor("Озеров", "Захар", "Максимович", "Светлая 13"
        //    , "998234", TypeDoctor.Therapist, "10", "15");
        //var dd3 = new Doctor("Зотова", "София", "Кирилловна", "Светлая 14"
        //    , "635475", TypeDoctor.Nurse, "15", "19");
        //d1.Add(dd1);
        //d1.Add(dd2);
        //d1.Add(dd3);

        //List<Doctor> d2 = new List<Doctor>();
        //var df1 = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
        //    , "999875", TypeDoctor.Surgeon, "08", "15");
        //var df2 = new Doctor("Кузнецова", "Полина", "Ивановна", "Светлая 16"
        //    , "123753", TypeDoctor.Surgeon, "10", "16");
        //var df3 = new Doctor("Елисеев", "Александр", "Григорьевич", "Светлая 17"
        //    , "764986", TypeDoctor.Nurse, "11", "17");
        //d2.Add(df1);
        //d2.Add(df2);
        //d2.Add(df3);

        //List<Doctor> d3 = new List<Doctor>();
        //var dg1 = new Doctor("Кузнецов", "Артём", "Ильич", "Светлая 18"
        //    , "543123", TypeDoctor.Therapist, "09", "12");
        //var dg2 = new Doctor("Коротков", "Фатима", "Романовна", "Светлая 19"
        //    , "412312", TypeDoctor.Therapist, "09", "14");
        //var dg3 = new Doctor("Гусев", "Савелий", "Алексеевич", "Советская 20"
        //    , "534523", TypeDoctor.Gynecologist, "09", "12");
        //var dg4 = new Doctor("Алексеев", "Леон", "Бравлстарсович", "Комната 603 4 общежитие"
        //    , "876235", TypeDoctor.Optometrist, "09", "14");
        //var dg5 = new Doctor("Яковлев", "Никита", "Миронович", "Многоножная 10"
        //    , "123754", TypeDoctor.Nurse, "09", "14");
        //var dg6 = new Doctor("Воробьев", "Никита", "Глебович", "Смертная 10"
        //    , "764754", TypeDoctor.Therapist, "09", "14");
        //d3.Add(dg1);
        //d3.Add(dg2);
        //d3.Add(dg3);
        //    d3.Add(dg4);
        //    d3.Add(dg5);
        //    d3.Add(dg6);
        //    hp.AddDepartment(new Department(cb1, d1, new List<Patient>()
        //        {
        //            new Patient("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid())
        //        }, "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
        //        TypeDepartment.Therapeutic, Guid.NewGuid()));
        //    hp.AddDepartment(new Department(cb2, d2, new List<Patient>()
        //        {
        //            new Patient("Иванов", "Константин", "Александрович", "Дуси Ковальчук 91 кв 101", Guid.NewGuid())
        //        }, "Хирургическое отделение <Нож печень и ты в морге>", "Свердловская 10/2",
        //        1, TypeDepartment.Surgical, Guid.NewGuid()));
        //    hp.AddDepartment(new Department(cb3, d3, new List<Patient>()
        //        {
        //            new Patient("Полином", "Полина", "Вячеславовна", "Богдана Хмельницкого 21 кв 195", Guid.NewGuid())
        //        }, "Терапевтическое отделение <Спешилов что ты сделал>", "Свердловская 10/3",
        //        1, TypeDepartment.Polyclinic, Guid.NewGuid()));
        //an.Notify(JsonConverter<Hospital>.SerializeObject(hp), TypeNotification.File);
        ////ApplicationContext db = new ApplicationContext();
        ////db.Departments.Add((Department)hp.Buildings.ToList()[0]);
        ////db.Departments.Add((Department)hp.Buildings.ToList()[1]);
        ////db.Departments.Add((Department)hp.Buildings.ToList()[2]);
        ////db.Hospital.Add(hp);
        ////foreach (var depart in hp.Buildings)
        ////{
        ////    foreach (var VARIABLE in depart.Doctors)
        ////    {
        ////        db.Doctors.Add(VARIABLE);
        ////    }
        ////}

        ////db.SaveChanges();
    }

    private static Hospital? ParseFile(string path)
    {
        if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
        try
        {
            var hp = JsonConverter<Hospital>.DeserializeObject(path);
            return hp;
        }
        catch
        {
            Console.WriteLine("Произошла ошибка с файлом!");
            ExitProgram();
        }

        return null;
    }

    private static void CheckArgs(string[] args, int num)
    {
        if (args.Length != num)
        {
            Console.WriteLine("Неверное количество аргументов командной строки!");
            ExitProgram();
        }
    }

    private static void ExitProgram()
    {
        Environment.Exit(0);
    }
}