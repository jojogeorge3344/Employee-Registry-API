using Application.CQRS.Employee.Command;
using Application.CQRS.Employee.Queries;
using Application.Models.EmployeeDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ISender mediatrsender;
        public EmployeeController(ISender mediatrsender)
        {
            this.mediatrsender = mediatrsender;
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertEmployee([FromBody] NewEmployeeDto employeeInsert)
        {
            bool isSuccess = await mediatrsender.Send(new CreateEmployeeRequest(employeeInsert));
            if (isSuccess)
            {
                return Ok("Employee Created Successfully.");
            }
            return BadRequest("Employee Not Created!");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDto updateEmployee)
        {
            bool isSuccessful = await mediatrsender.Send(new UpdateEmployeeRequest(updateEmployee));
            if(isSuccessful)
            {
                return Ok("Employee Update Successfully.");
            }
            return BadRequest("Employee Not Updated!");
        }

        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeDetailsById(int id)
        {
            GetEmployeeDto getEmployee = await mediatrsender.Send(new GetEmployeeRequestByIdRequest(id));
            if(getEmployee != null)
            {
                return Ok(getEmployee);
            }
            return NotFound("Employee Details Not Available in DB!");
        }

        [HttpGet("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {
            List<GetEmployeeDto> getEmployeeList = await mediatrsender.Send(new GetEmployeeListRequest());
            if (getEmployeeList != null)
            {
                return Ok(getEmployeeList);
            }
            return NotFound("Employee Details Not Available in DB!");
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
           bool isSuccess = await mediatrsender.Send(new DeleteEmployeeRequest(id));
            if (isSuccess)
            {
                return Ok("Employee Deleted Successfully.");
            }
            return NotFound("Employee Details Not Available in DB!");
        }
    }
}
