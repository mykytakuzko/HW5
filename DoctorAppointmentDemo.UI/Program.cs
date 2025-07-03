using DoctorAppointmentDemo.Data.Serialization;

namespace MyDoctorAppointment
{
    public static class Program
    {
        public static void Main()
        {
            bool canContinue = true;
            ISerialization serialization = null;

            while (canContinue)
            {
                Console.WriteLine("Select the format: JSON | XML");
                string format = DoctorAppointment.GetDataFromConsole();

                switch (format)
                {
                    case "JSON":
                        serialization = new JsonSerialization();
                        canContinue = false;
                        break;
                    case "XML":
                        serialization = new XmlSerialization();
                        canContinue = false;
                        break;
                    default:
                        Console.WriteLine("You must select only JSON or XML");
                        break;
                }
            }
            
            var doctorAppointment = new DoctorAppointment(serialization);
            doctorAppointment.Menu();
        }
    }
}