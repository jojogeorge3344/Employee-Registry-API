using Application.CQRS.JobDetails.Command;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDetailsController : ControllerBase
    {
        private readonly ISender mediatrsender;
        public JobDetailsController(ISender mediatrsender)
        {
            this.mediatrsender = mediatrsender;
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertJobDetail([FromBody] JobDetails jobDetails)
        {
            bool isSuccess = await mediatrsender.Send(new CreateJobDetailRequest(jobDetails));
            if (isSuccess)
            {
                return Ok("JobDetail Created Successfully.");
            }
            return BadRequest("JobDetail Not Created!");
        }
    }
}
