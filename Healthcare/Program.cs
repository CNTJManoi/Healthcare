using Healthcare.Json;
using Healthcare.Menu;
using Healthcare.Models;
using Healthcare.Models.Separations;
using Healthcare.Models.Separations.Models;

namespace Healthcare;

internal class Program
{
    private static void Main(string[] args)
    {
        //Hospital? hp;
        //if (args.Count() != 2)
        //{
        //    Console.WriteLine("Недостаточно аргументов командной строки!");
        //    return;
        //}

        //try
        //{
        //    hp = JsonConverter<Hospital>.DeserializeObject(args[0]);
        //}
        //catch
        //{
        //    Console.WriteLine("Произошла ошибка с файлом!");
        //    return;
        //}

        //var hm = new HospitalMenu(hp, args[1]);
        //hm.Start();

        Hospital hp = new Hospital("Яркое солнышко");
        List<Cabinet> cb1 = new List<Cabinet>();
        cb1.Add(new Cabinet(TypeDoctor.Paramedic, 101));
        cb1.Add(new Cabinet(TypeDoctor.Therapist, 102));
        cb1.Add(new Cabinet(TypeDoctor.Therapist, 103));
        cb1.Add(new Cabinet(TypeDoctor.Nurse, 104));
        List<Cabinet> cb2 = new List<Cabinet>();
        cb2.Add(new Cabinet(TypeDoctor.Surgeon, 101));
        cb2.Add(new Cabinet(TypeDoctor.Surgeon, 102));
        cb2.Add(new Cabinet(TypeDoctor.Nurse, 103));
        cb2.Add(new Cabinet(TypeDoctor.Surgeon, 104));
        List<Cabinet> cb3 = new List<Cabinet>();
        cb3.Add(new Cabinet(TypeDoctor.Therapist, 101));
        cb3.Add(new Cabinet(TypeDoctor.Therapist, 102));
        cb3.Add(new Cabinet(TypeDoctor.Gynecologist, 103));
        cb3.Add(new Cabinet(TypeDoctor.Optometrist, 104));
        cb3.Add(new Cabinet(TypeDoctor.Nurse, 105));
        cb3.Add(new Cabinet(TypeDoctor.Therapist, 106));
        hp.AddDepartment(new Department(cb1, "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1, TypeDepartment.Therapeutic));
        hp.AddDepartment(new Department(cb2, "Хирургическое отделение <Нож печень и ты в морге>", "Свердловская 10/2", 1, TypeDepartment.Surgical));
        hp.AddDepartment(new Department(cb3, "Терапевтическое отделение <Спешилов что ты сделал>", "Свердловская 10/3", 1, TypeDepartment.Polyclinic));
        hp.AddDoctor(new Doctor("Потапов", "Алексей", "Даниилович", "Светлая 12"
            , "654767", TypeDoctor.Paramedic, "09", "15"), 1);
        hp.AddDoctor(new Doctor("Озеров", "Захар", "Максимович", "Светлая 13"
            , "998234", TypeDoctor.Therapist, "10", "15"), 1);
        hp.AddDoctor(new Doctor("Зотова", "София", "Кирилловна", "Светлая 14"
            , "635475", TypeDoctor.Nurse, "15", "19"), 1);

        hp.AddDoctor(new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15"), 2);
        hp.AddDoctor(new Doctor("Кузнецова", "Полина", "Ивановна", "Светлая 16"
            , "123753", TypeDoctor.Surgeon, "10", "16"), 2);
        hp.AddDoctor(new Doctor("Елисеев", "Александр", "Григорьевич", "Светлая 17"
            , "764986", TypeDoctor.Nurse, "11", "17"), 2);

        hp.AddDoctor(new Doctor("Кузнецов", "Артём", "Ильич", "Светлая 18"
            , "543123", TypeDoctor.Therapist, "09", "12"), 3);
        hp.AddDoctor(new Doctor("Коротков", "Фатима", "Романовна", "Светлая 19"
            , "412312", TypeDoctor.Therapist, "09", "14"), 3);
        hp.AddDoctor(new Doctor("Гусев", "Савелий", "Алексеевич", "Советская 20"
            , "534523", TypeDoctor.Gynecologist, "09", "12"), 3);
        hp.AddDoctor(new Doctor("Алексеев", "Леон", "Бравлстарсович", "Комната 603 4 общежитие"
            , "876235", TypeDoctor.Optometrist, "09", "14"), 3);
        hp.AddDoctor(new Doctor("Яковлев", "Никита", "Миронович", "Многоножная 10"
            , "123754", TypeDoctor.Nurse, "09", "14"), 3);
        hp.AddDoctor(new Doctor("Воробьев", "Никита", "Глебович", "Смертная 10"
            , "764754", TypeDoctor.Therapist, "09", "14"), 3);
        JsonConverter<Hospital>.SerializeObject(hp, "hospitalNew.json");
    }
}