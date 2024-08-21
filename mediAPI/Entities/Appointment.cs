using System.ComponentModel.DataAnnotations;

namespace medAPI.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string AppointmentTitle { get; set; }
        public string AppointmentDescription { get; set; }
        public DateTime VisitDate { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }





    }
}
