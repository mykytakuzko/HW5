using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Enums;
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
            while (true)
            {
                Console.Write("Chose the entity you want to work with: ");
                ShowEnumValues<Menu>();

                Menu entity = GetSelectedMenu("You must chose the menu from the list above: ");

                if (entity == Enums.Menu.Exit)
                {
                    return;
                }

                Console.Write("Chose the operation you want to do: ");
                ShowEnumValues<SubMenu>();

                SubMenu subEntity = GetSelectedSubMenu("You must chose the menu from the list above: ");

                switch (entity)
                {
                    case Enums.Menu.Appointments:
                        switch (subEntity)
                        {
                            case SubMenu.ShowAll:
                                ShowAllAppointment();
                                break;
                            case SubMenu.Show:
                                ShowAppointmentById();
                                break;
                            case SubMenu.Update:
                                UpdateAppointment(new Appointment("Test description"));
                                break;
                            case SubMenu.Add:
                                AddNewAppointment(new Appointment("Test description №2"));
                                break;
                            case SubMenu.Delete:
                                DeleteAppointment();
                                break;
                        }
                        break;
                    case Enums.Menu.Doctors:
                        switch (subEntity)
                        {
                            case SubMenu.ShowAll:
                                ShowAllDoctors();
                                break;
                            case SubMenu.Show:
                                ShowDoctorById();
                                break;
                            case SubMenu.Update:
                                UpdateDoctor(new Doctor("Update doctor"));
                                break;
                            case SubMenu.Add:
                                AddNewDoctor(new Doctor("New test doctor"));
                                break;
                            case SubMenu.Delete:
                                DeleteDoctor();
                                break;
                        }
                        break;
                    case Enums.Menu.Patients:
                        switch (subEntity)
                        {
                            case SubMenu.ShowAll:
                                ShowAllPatients();
                                break;
                            case SubMenu.Show:
                                ShowPatientById();
                                break;
                            case SubMenu.Update:
                                UpdatePatient(new Patient("Test name"));
                                break;
                            case SubMenu.Add:
                                AddNewPatient(new Patient("New test patient"));
                                break;
                            case SubMenu.Delete:
                                DeletePatient();
                                break;
                        }
                        break;
                }
            }
        }

        private void ShowAllAppointment()
        {
            Console.WriteLine("Current appointments list: ");
            var appointments = _appointmentService.GetAll();

            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment);
            }
        }

        private void ShowAllPatients()
        {
            Console.WriteLine("Current patients list: ");
            var patients = _patientService.GetAll();

            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
            }
        }

        private void ShowAllDoctors()
        {
            Console.WriteLine("Current doctors list: ");
            var doctors = _doctorService.GetAll();

            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor);
            }
        }

        private void ShowAppointmentById()
        {
            Console.Write("Enter an 'Id' for an appointment which want to show: ");
            while (true)
            {
                int id = GetIntFromConsole();
                try
                {
                    Console.WriteLine(_appointmentService.Get(id).Description);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again: ");
                }
            }
        }

        private void ShowPatientById()
        {
            Console.Write("Enter an 'Id' for a patient which want to show: ");
            while (true)
            {
                int id = GetIntFromConsole();
                try
                {
                    Console.WriteLine(_patientService.Get(id).Name);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again: ");
                }
            }
        }

        private void ShowDoctorById()
        {
            Console.Write("Enter an 'Id' for a doctor which want to show: ");
            while (true)
            {
                int id = GetIntFromConsole();
                try
                {
                    Console.WriteLine(_doctorService.Get(id).Name);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again: ");
                }
            }
        }

        //TODO change method and get new appointment from console
        private void UpdateAppointment(Appointment appointment)
        {
            Console.Write("Enter an 'Id' for an appointment which want to update: ");
            while (true)
            {
                int id = GetIntFromConsole();
                try
                {
                    _appointmentService.Update(id, appointment);
                    Console.WriteLine(_appointmentService.Get(id).Description);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again: ");
                }
            }
        }

        //TODO change method and get new patient from console
        private void UpdatePatient(Patient patient)
        {
            Console.Write("Enter an 'Id' for a patient which want to update: ");
            while (true)
            {
                int id = GetIntFromConsole();
                try
                {
                    _patientService.Update(id, patient);
                    Console.WriteLine(_patientService.Get(id));
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again: ");
                }
            }
        }

        //TODO change method and get new doctor from console
        private void UpdateDoctor(Doctor doctor)
        {
            Console.Write("Enter an 'Id' for a doctor which want to update: ");
            while (true)
            {
                int id = GetIntFromConsole();
                try
                {
                    _doctorService.Update(id, doctor);
                    Console.WriteLine(_doctorService.Get(id).Name);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again: ");
                }
            }
        }

        //TODO change method and get new appointment from console
        private void AddNewAppointment(Appointment appointment)
        {
            _appointmentService.Create(appointment);
            var appointments = _appointmentService.GetAll();

            foreach (var aptm in appointments)
            {
                Console.WriteLine(aptm.Description);
            }
        }

        //TODO change method and get new patient from console
        private void AddNewPatient(Patient patient)
        {
            _patientService.Create(patient);
            var patients = _patientService.GetAll();

            foreach (var ptn in patients)
            {
                Console.WriteLine(ptn.Name);
            }
        }

        //TODO change method and get new doctor from console
        private void AddNewDoctor(Doctor doctor)
        {
            _doctorService.Create(doctor);
            var doctors = _doctorService.GetAll();

            foreach (var doc in doctors)
            {
                Console.WriteLine(doc.Name);
            }
        }

        private void DeleteAppointment()
        {
            Console.Write("Enter an 'Id' for an appointment which want to delete: ");
            while (true)
            {
                int id = GetIntFromConsole();
                try
                {
                    _appointmentService.Get(id);
                    _appointmentService.Delete(id);
                    ShowAllAppointment();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again: ");
                }
            }
        }

        private void DeletePatient()
        {
            Console.Write("Enter an 'Id' for a patient which want to delete: ");
            while (true)
            {
                int id = GetIntFromConsole();
                try
                {
                    _patientService.Get(id);
                    _patientService.Delete(id);
                    ShowAllPatients();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again: ");
                }
            }
        }

        private void DeleteDoctor()
        {
            Console.Write("Enter an 'Id' for a doctor which want to delete: ");
            while (true)
            {
                int id = GetIntFromConsole();
                try
                {
                    _doctorService.Get(id);
                    _doctorService.Delete(id);
                    ShowAllDoctors();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Try again: ");
                }
            }
        }

        private Menu GetSelectedMenu(string errorText)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || !Enum.TryParse(input, true, out Menu result))
                {
                    Console.Write(errorText);
                }
                else
                {
                    return result;
                }
            }
        }

        private SubMenu GetSelectedSubMenu(string errorText)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || !Enum.TryParse(input, true, out SubMenu result))
                {
                    Console.Write(errorText);
                }
                else
                {
                    return result;
                }
            }
        }

        private void ShowEnumValues<T>() where T : Enum
        {
            var enums = Enum.GetNames(typeof(T));
            Console.WriteLine(string.Join(" | ", enums));
        }

        private static string GetDataFromConsole()
        {
            while (true)
            {
                string result = Console.ReadLine();

                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }
                else
                {
                    Console.Write("Input can not be empty, try again: ");
                }
            }
        }

        private int GetIntFromConsole()
        {
            while (true)
            {
                string input = GetDataFromConsole();

                try
                {
                    return Int32.Parse(input);
                }
                catch (FormatException e)
                {
                    Console.Write($"{e.Message} You must enter a number! Try again: ");
                }
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