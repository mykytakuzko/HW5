namespace MyDoctorAppointment.Domain.Entities
{
    public class Appointment : Auditable
    {
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public string? Description { get; set; }
        
        public Appointment() {}
        
        public Appointment(string description)
        {
            Description = description;
        }

        public override string ToString()
        {
            return $"[Id: {Id}, CreatedAt: {CreatedAt}, Description: {Description}" +
                   $", Patient: {Patient?.Name}, Doctor: {Doctor?.Name}]";
        }
    }
}
