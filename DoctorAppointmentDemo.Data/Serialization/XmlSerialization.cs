using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DoctorAppointmentDemo.Data.Serialization;

public class XmlSerialization : ISerialization
{
    public string Path { get; set; } = "XMLPath";
    public string LastId { get; set; } = "XMLLastId";
    
    public void SerializeToFile<T>(IEnumerable<T> items, string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            serializer.Serialize(writer, items.ToList());
        }
    }
    
    public IEnumerable<T> DeserializeFromFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
            return new List<T>();

        var serializer = new XmlSerializer(typeof(List<T>));
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            return (List<T>)serializer.Deserialize(stream)!;
        }
    }
}