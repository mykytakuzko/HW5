using DoctorAppointmentDemo.Data.Serialization;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentsRepository;

    public AppointmentService(ISerialization serializer)
    {
        _appointmentsRepository = new AppointmentRepository(serializer);
    }

    public Appointment Create(Appointment appointment)
    {
        return _appointmentsRepository.Create(appointment);
    }

    public bool Delete(int id)
    {
        return _appointmentsRepository.Delete(id);
    }

    public Appointment? Get(int id)
    {
        Appointment appointment = _appointmentsRepository.GetById(id);

        if (appointment == null)
        {
            throw new Exception($"Appointment with this id '{id}' does not exist.");
        }

        return appointment;
    }

    public IEnumerable<Appointment> GetAll()
    {
        return _appointmentsRepository.GetAll();
    }

    public Appointment Update(int id, Appointment appointment)
    {
        return _appointmentsRepository.Update(id, appointment);
    }
}