using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Patient : UserBase
    {
        public IllnessTypes IllnessType { get; set; }

        public string? AdditionalInfo { get; set; }

        public string? Address { get; set; }
        
        public Patient() {}

        public Patient(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"[Id: {Id}, CreatedAt: {CreatedAt}, Name: {Name}, Surname: {Surname}, IllnessType: {IllnessType}" +
                   $", AdditionalInfo: {AdditionalInfo}]";
        }
    }
}
