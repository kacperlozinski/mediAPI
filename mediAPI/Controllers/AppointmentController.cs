using medAPI.Models;
using medAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace medAPI.Controllers
{
    [Route("med")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AppointmentDto>> GetAllAppointments()
        {
            var appointmentsDtos = _appointmentService.GetAll();
            System.Diagnostics.Debug.WriteLine("chuj2");
            return Ok(appointmentsDtos);
        }
        [HttpGet("getAppointment/{id}")]

        public ActionResult GetOne(int id)
        {
            var appointmentDtos = _appointmentService.GetAppointment(id);

            return Ok(appointmentDtos);

        }

        [HttpPost]
        public ActionResult CreateAppointment([FromBody] CreateAppointmentDto dto)
        {
            var id = _appointmentService.Create(dto);

            return Created($"appointment/{id}", null);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateAppointment([FromBody] UpdateAppointmentDto dto, [FromRoute] int id)
        {
            _appointmentService.Update(dto, id);

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAppointment([FromRoute] int id)
        {
            _appointmentService.Delete(id);
            return NoContent();
        }

        


    }
}
