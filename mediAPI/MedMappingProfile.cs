using AutoMapper;
using medAPI.Entities;
using medAPI.Models;

namespace medAPI
{
    public class MedMappingProfile : Profile
    {
        public MedMappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(m => m.DoctorId, c => c.MapFrom(s => s.Doctor.DoctorId))
                .ForMember(m => m.PatientId, c => c.MapFrom(s => s.Patient.PatientId));
            CreateMap<CreateAppointmentDto, Appointment>();
        }
    }
}
