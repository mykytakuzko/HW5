using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;

        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
            _appointmentService = new AppointmentService();
            _patientService = new PatientService();
        }

        public void Menu()
        {
            //while (true)
            //{
            //    // add Enum for menu items and describe menu
            //}
            
            Console.WriteLine("Current appointments list: ");
            var patients = _patientService.GetAll();

            foreach (var patient in patients)
            {
                Console.WriteLine(patient.Name);
            }
            
            Console.WriteLine("Adding patient: ");

            var newpatient = new Patient{
                Name = "Ivan"
            };

            _patientService.Create(newpatient);
            
            Console.WriteLine("Current patients list: ");
            patients = _patientService.GetAll();

            foreach (var patient in patients)
            {
                Console.WriteLine(patient.Name);
            }
            
            Console.WriteLine("Current appointments list: ");
            var appointments = _appointmentService.GetAll();

            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment.Description);
            }
            
            Console.WriteLine("Adding appointment: ");

            var newAppointment = new Appointment{
                Description = "Test"
            };

            _appointmentService.Create(newAppointment);
            
            Console.WriteLine("Current appointments list: ");
            appointments = _appointmentService.GetAll();

            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment.Description);
            }

            Console.WriteLine("Current doctors list: ");
            var docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Name);
            }

            Console.WriteLine("Adding doctor: ");

            var newDoctor = new Doctor
            {
                Name = "Vasya",
                Surname = "Petrov",
                Experience = 20,
                DoctorType = Domain.Enums.DoctorTypes.Dentist
            };

            _doctorService.Create(newDoctor);

            Console.WriteLine("Current doctors list: ");
            docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Name);
            }
        }
    }

    public static class Program
    {
        public static void Main()
        {
            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();
        }
    }
}