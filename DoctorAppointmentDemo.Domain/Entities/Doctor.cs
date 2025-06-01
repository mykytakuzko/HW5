using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Doctor : UserBase
    {
        public DoctorTypes DoctorType { get; set; }

        public byte Experience { get; set; }

        public decimal Salary { get; set; }
        
        public Doctor() {}

        public Doctor(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"[Id: {Id}, CreatedAt: {CreatedAt}, Name: {Name}, Surname: {Surname}, DoctorType: {DoctorType}" +
                   $", Experience: {Experience}, Salary: {Salary}]";
        }
    }
}
