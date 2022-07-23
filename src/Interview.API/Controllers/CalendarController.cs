using Interview.Application.InputModels;
using Interview.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarServiceApplication _calendarServiceApplication;
        public CalendarController(ICalendarServiceApplication calendarServiceApplication)
        {
            _calendarServiceApplication = calendarServiceApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CalendarInputModel calendarInput) {
            var result = await _calendarServiceApplication.CandidateAvailabilityWithInterviewers(calendarInput);
            if (result.IsSuccess)
                return Ok(result);

            return NotFound(result);
        }
    }
}
