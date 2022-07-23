using Interview.Application.InputModels;
using Interview.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateServiceApplication _candidateServiceApplication;

        public CandidateController(ICandidateServiceApplication candidateServiceApplication)
        {
            _candidateServiceApplication = candidateServiceApplication;
        }
    

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _candidateServiceApplication.GetCandidateAvailabilityByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CandidateInputModel candidateInputModel)
        {
            var result = await _candidateServiceApplication.AddCandidateAvailabilityAsync(candidateInputModel);
            if (result.IsSuccess)
                return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _candidateServiceApplication.DeleteCandidateAvailabilityAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
