using Healthcare.Json;
using Healthcare.Menu;

namespace Healthcare;

internal class Program
{
    private static void Main(string[] args)
    {
        Hospital hp;
        CheckArgs(args, 2);
        var hm = new HospitalMenu(ParseFile(args[0]), args[1]);
        hm.Start();
    }

    private static Hospital ParseFile(string path)
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
        if (args.Count() != num)
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