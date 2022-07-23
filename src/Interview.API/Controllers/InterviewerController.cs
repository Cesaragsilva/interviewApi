using Interview.Application.InputModels;
using Interview.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerServiceApplication _interviewerServiceApplication;

        public InterviewerController(IInterviewerServiceApplication interviewerServiceApplication)
        {
            _interviewerServiceApplication = interviewerServiceApplication;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _interviewerServiceApplication.GetInterviewerAvailabilityByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InterviewerInputModel interviewer)
        {
            var result = await _interviewerServiceApplication.AddInterviewerAvailabilityAsync(interviewer);
            if (result.IsSuccess)
                return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _interviewerServiceApplication.DeleteInterviewerAvailabilityAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
