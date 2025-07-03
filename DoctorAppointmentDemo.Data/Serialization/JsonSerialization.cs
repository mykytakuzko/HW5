using Newtonsoft.Json;

namespace DoctorAppointmentDemo.Data.Serialization;

public class JsonSerialization : ISerialization
{
    public string Path { get; set; } = "JSONPath";
    public string LastId { get; set; } = "JSONLastId";
    
    public void SerializeToFile<T>(IEnumerable<T> items, string filePath)
    {
        var json = JsonConvert.SerializeObject(items, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public IEnumerable<T> DeserializeFromFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
            return new List<T>();

        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<T>>(json)!;
    }
}