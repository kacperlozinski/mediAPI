using System.Diagnostics;

namespace medAPI.Models
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string AppointmentTitle { get; set; }
        public string AppointmentDescription { get; set; }
        public DateTime VisitDate { get; set; }

        

    }
}
