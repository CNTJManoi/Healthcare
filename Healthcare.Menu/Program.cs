using Healthcare.Database;
using Healthcare.Json;
using Healthcare.Logic;
using Healthcare.Notification;

namespace Healthcare.Menu;

internal class Program
{
    //паттерн композитор. Инкапсуляция починилась
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

        //var hp = new Hospital("Яркое солнышко");
        //var cb1 = new List<Cabinet>();
        //cb1.Add(new Cabinet(TypeDoctor.Paramedic, 101));
        //cb1.Add(new Cabinet(TypeDoctor.Therapist, 102));
        //cb1.Add(new Cabinet(TypeDoctor.Therapist, 103));
        //cb1.Add(new Cabinet(TypeDoctor.Nurse, 104));
        //var cb2 = new List<Cabinet>();
        //cb2.Add(new Cabinet(TypeDoctor.Surgeon, 101));
        //cb2.Add(new Cabinet(TypeDoctor.Surgeon, 102));
        //cb2.Add(new Cabinet(TypeDoctor.Nurse, 103));
        //cb2.Add(new Cabinet(TypeDoctor.Surgeon, 104));
        //var cb3 = new List<Cabinet>();
        //cb3.Add(new Cabinet(TypeDoctor.Therapist, 101));
        //cb3.Add(new Cabinet(TypeDoctor.Therapist, 102));
        //cb3.Add(new Cabinet(TypeDoctor.Gynecologist, 103));
        //cb3.Add(new Cabinet(TypeDoctor.Optometrist, 104));
        //cb3.Add(new Cabinet(TypeDoctor.Nurse, 105));
        //cb3.Add(new Cabinet(TypeDoctor.Therapist, 106));
        //hp.AddDepartment(new Department(cb1, "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
        //    TypeDepartment.Therapeutic));
        //hp.AddDepartment(new Department(cb2, "Хирургическое отделение <Нож печень и ты в морге>", "Свердловская 10/2",
        //    1, TypeDepartment.Surgical));
        //hp.AddDepartment(new Department(cb3, "Терапевтическое отделение <Спешилов что ты сделал>", "Свердловская 10/3",
        //    1, TypeDepartment.Polyclinic));
        //hp.AddDoctor(new Doctor("Потапов", "Алексей", "Даниилович", "Светлая 12"
        //    , "654767", TypeDoctor.Paramedic, "09", "15"), 1);
        //hp.AddDoctor(new Doctor("Озеров", "Захар", "Максимович", "Светлая 13"
        //    , "998234", TypeDoctor.Therapist, "10", "15"), 1);
        //hp.AddDoctor(new Doctor("Зотова", "София", "Кирилловна", "Светлая 14"
        //    , "635475", TypeDoctor.Nurse, "15", "19"), 1);

        //hp.AddDoctor(new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
        //    , "999875", TypeDoctor.Surgeon, "08", "15"), 2);
        //hp.AddDoctor(new Doctor("Кузнецова", "Полина", "Ивановна", "Светлая 16"
        //    , "123753", TypeDoctor.Surgeon, "10", "16"), 2);
        //hp.AddDoctor(new Doctor("Елисеев", "Александр", "Григорьевич", "Светлая 17"
        //    , "764986", TypeDoctor.Nurse, "11", "17"), 2);

        //hp.AddDoctor(new Doctor("Кузнецов", "Артём", "Ильич", "Светлая 18"
        //    , "543123", TypeDoctor.Therapist, "09", "12"), 3);
        //hp.AddDoctor(new Doctor("Коротков", "Фатима", "Романовна", "Светлая 19"
        //    , "412312", TypeDoctor.Therapist, "09", "14"), 3);
        //hp.AddDoctor(new Doctor("Гусев", "Савелий", "Алексеевич", "Советская 20"
        //    , "534523", TypeDoctor.Gynecologist, "09", "12"), 3);
        //hp.AddDoctor(new Doctor("Алексеев", "Леон", "Бравлстарсович", "Комната 603 4 общежитие"
        //    , "876235", TypeDoctor.Optometrist, "09", "14"), 3);
        //hp.AddDoctor(new Doctor("Яковлев", "Никита", "Миронович", "Многоножная 10"
        //    , "123754", TypeDoctor.Nurse, "09", "14"), 3);
        //hp.AddDoctor(new Doctor("Воробьев", "Никита", "Глебович", "Смертная 10"
        //    , "764754", TypeDoctor.Therapist, "09", "14"), 3);
        ////JsonConverter<Hospital>.SerializeObject(hp, "hospitalNew.json");
        //ApplicationContext db = new ApplicationContext();
        //db.Departments.Add((Department)hp.Buildings.ToList()[0]);
        //db.Departments.Add((Department)hp.Buildings.ToList()[1]);
        //db.Departments.Add((Department)hp.Buildings.ToList()[2]);
        //db.Hospital.Add(hp);
        //foreach (var depart in hp.Buildings)
        //{
        //    foreach (var VARIABLE in depart.Doctors)
        //    {
        //        db.Doctors.Add(VARIABLE);
        //    }
        //}

        //db.SaveChanges();
    }

    private static Hospital? ParseFile(string path)
    {
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