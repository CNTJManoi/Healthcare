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

    public static void SerializeObject(T entity, string pathFile)
    {
        if (File.Exists(pathFile)) File.Delete(pathFile);
        File.Create(pathFile).Close();
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };
        File.WriteAllText(pathFile, JsonConvert.SerializeObject(entity, Formatting.Indented, settings));
    }
}