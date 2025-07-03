namespace DoctorAppointmentDemo.Data.Serialization;

public interface ISerialization
{
    void SerializeToFile<T>(IEnumerable<T> items, string filePath);
    IEnumerable<T> DeserializeFromFile<T>(string filePath);
    string Path { get; set; }
    string LastId { get; set; }
}