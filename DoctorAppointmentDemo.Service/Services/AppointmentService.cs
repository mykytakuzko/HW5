using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentsRepository;

    public AppointmentService()
    {
        _appointmentsRepository = new AppointmentRepository();
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
        return _appointmentsRepository.GetById(id);
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