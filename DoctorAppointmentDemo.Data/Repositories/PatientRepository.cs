using DoctorAppointmentDemo.Data.Serialization;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    public override string Path { get; set; }
    public override int LastId { get; set; }

    public PatientRepository(ISerialization serialization) : base(serialization)
    {
        // dynamic result = ReadFromAppSettings();
        //
        // Path = result.Database.Patients.Path;
        // LastId = result.Database.Patients.LastId;
    }
    
    public override void ShowInfo(Patient patient)
    {
        Console.WriteLine();
    }
    
    protected override void SaveLastId()
    {
        dynamic result = ReadFromAppSettings();
        result.Database.Patients[_serialization.LastId] = LastId;
        
        File.WriteAllText(Constants.AppSettingsPath, result.ToString());
    }
}