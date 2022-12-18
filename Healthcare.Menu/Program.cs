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