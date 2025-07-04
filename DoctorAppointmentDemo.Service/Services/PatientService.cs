using DoctorAppointmentDemo.Data.Serialization;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(ISerialization serializer)
    {
        _patientRepository = new PatientRepository(serializer);
    }

    public Patient Create(Patient patient)
    {
        return _patientRepository.Create(patient);
    }

    public bool Delete(int id)
    {
        return _patientRepository.Delete(id);
    }

    public Patient? Get(int id)
    {
        Patient patient = _patientRepository.GetById(id);

        if (patient == null)
        {
            throw new Exception($"Patient with this id '{id}' does not exist.");
        }
        return patient;
    }

    public IEnumerable<Patient> GetAll()
    {
        return _patientRepository.GetAll();
    }

    public Patient Update(int id, Patient patient)
    {
        return _patientRepository.Update(id, patient);
    }
}