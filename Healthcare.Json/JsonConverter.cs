using Newtonsoft.Json;

namespace Healthcare.Json;

public static class JsonConverter<T>
{
    public static T? DeserializeObject(string pathFile)
    {
        var fileInfo = new FileInfo(pathFile);
        if (!fileInfo.Exists) throw new FileNotFoundException("File not exists!");
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };
        var test = JsonConvert.DeserializeObject<T>(File.ReadAllText(pathFile), settings);
        return test;
    }

    public static string SerializeObject(T entity)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };
        return JsonConvert.SerializeObject(entity, Formatting.Indented, settings);
    }
}