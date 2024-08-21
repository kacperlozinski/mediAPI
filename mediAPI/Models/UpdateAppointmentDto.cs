namespace medAPI.Models
{
    public class UpdateAppointmentDto
    {
     
        public int DoctorId { get; set; }
        public string AppointmentTitle { get; set; }
        public string AppointmentDescription { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
