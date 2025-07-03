using DoctorAppointmentDemo.Data.Serialization;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    public override string Path { get; set; }
    public override int LastId { get; set; }

    public AppointmentRepository(ISerialization serializer) : base(serializer)
    {
        // dynamic result = ReadFromAppSettings();
        //
        // Path = result.Database.Appointments.Path;
        // LastId = result.Database.Appointments.LastId;
    }

    public override void ShowInfo(Appointment appointment)
    {
        Console.WriteLine();
    }

    protected override void SaveLastId()
    {
        dynamic result = ReadFromAppSettings();
        result.Database.Appointments[_serialization.LastId] = LastId;
        
        File.WriteAllText(Constants.AppSettingsPath, result.ToString());
    }
}