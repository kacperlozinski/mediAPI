using System.ComponentModel.DataAnnotations;

namespace medAPI.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; } 

        public int UserId { get; set; }

        public int AppointmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

       public virtual User User { get; set; }

        public ICollection<Appointment> Appointments { get; set; }






    }
}
