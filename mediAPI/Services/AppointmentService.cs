using AutoMapper;
using medAPI.Entities;
using medAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace medAPI.Services
{
    public interface IAppointmentService
    {
        public IEnumerable<AppointmentDto> GetAll();
        public AppointmentDto GetAppointment(int id);
        public int Create(CreateAppointmentDto dto);
        public void Update(UpdateAppointmentDto dto, int id);
        void Delete(int id);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly MedDbContext _dbContext;
        private readonly IMapper _mapper;

        public AppointmentService(MedDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public IEnumerable<AppointmentDto> GetAll()
        {
            System.Diagnostics.Debug.WriteLine("chuj3");
            var appointments = _dbContext
                                .Appointments
                                .Include(r => r.Doctor)
                                .Include(r => r.Patient)
                                .ToList();

            var appointmentsDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            System.Diagnostics.Debug.WriteLine("chuj1");

            return appointmentsDtos;

        }

        public AppointmentDto GetAppointment(int id)
        {
            var appointment = _dbContext
                        .Appointments
                        .Include(r => r.Doctor)
                        .Include(r => r.Patient)
                        .FirstOrDefault(a => a.AppointmentId == id);
            if(appointment is null) 
                {
                System.Diagnostics.Debug.WriteLine("chuj1");

            }

            var result = _mapper.Map<AppointmentDto>(appointment);

            return result;
        }

        public int Create(CreateAppointmentDto dto)
        { 
            var appointment = _mapper.Map<AppointmentDto>(dto);
            //dodać mapping ale poprawny 

            _dbContext.Add(appointment);
            _dbContext.SaveChanges();

            return appointment.AppointmentId;
        }
       public void Update(UpdateAppointmentDto dto, int id)
        {
            var appointment = _dbContext
                            .Appointments
                            .FirstOrDefault(r => r.AppointmentId == id);

            if (appointment is null)
            {
                return;
            }
            appointment.AppointmentTitle = dto.AppointmentTitle ?? appointment.AppointmentTitle;
            appointment.AppointmentDescription = dto.AppointmentDescription ?? appointment.AppointmentDescription;
            if (appointment.DoctorId != dto.DoctorId)
                appointment.DoctorId = dto.DoctorId;

            if (appointment.VisitDate != dto.VisitDate)
                appointment.VisitDate = dto.VisitDate;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointment = _dbContext
                .Appointments
                .FirstOrDefault (r => r.AppointmentId == id);
            if (appointment is null)
            {
                return;
            }
            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();
           
        }

    }
}
