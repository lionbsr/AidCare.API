using AidCare.Business.Abstract;
using AidCare.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AidCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodGlucoseController : ControllerBase
    {
        private readonly IBloodGlucoseService _glucoseService;

        public BloodGlucoseController(IBloodGlucoseService glucoseService)
        {
            _glucoseService = glucoseService;
        }

        // POST: api/BloodGlucose
        [HttpPost]
        public IActionResult Add([FromBody] BloodGlucose glucose)
        {
            _glucoseService.Add(glucose);
            return Ok("Glucose added successfully.");
        }

        // GET: api/BloodGlucose/user/1
        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var values = _glucoseService.GetByUserId(userId);
            return Ok(values);
        }

        // PUT: api/BloodGlucose/3
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BloodGlucose updatedGlucose)
        {
            var glucose = _glucoseService.GetById(id);
            if (glucose == null)
                return NotFound("Glucose entry not found.");

            glucose.GlucoseValue = updatedGlucose.GlucoseValue;
            glucose.MeasurementTime = updatedGlucose.MeasurementTime;

            _glucoseService.Update(glucose);
            return Ok("Updated successfully.");
        }

        // DELETE: api/BloodGlucose/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var glucose = _glucoseService.GetById(id);
            if (glucose == null)
                return NotFound("Glucose entry not found.");

            _glucoseService.Delete(id);
            return Ok("Deleted successfully.");
        }
    }
}
