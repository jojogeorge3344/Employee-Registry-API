using Application.Models.EmployeeDtos;
using Application.Repositories;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Employee.Command
{
    public class UpdateEmployeeRequest : IRequest<bool>
    {
        public UpdateEmployeeDto updateEmployee { get; set; }

        public UpdateEmployeeRequest(UpdateEmployeeDto updateEmployee)
        {
            this.updateEmployee = updateEmployee;
        }
    }

    public class UpdateEmployeeRequestHandler : IRequestHandler<UpdateEmployeeRequest, bool>
    {
        private readonly IEmployeeRepository employeeRepository;

        public UpdateEmployeeRequestHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;  
        }

        public async Task<bool> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            //check data exist in DB
            Domain.Models.Employee detailsInDb = await employeeRepository.GetByIdAsync(request.updateEmployee.Id);

            //update data to employee table
            if(detailsInDb != null)
            {
                detailsInDb.EmployeeName = request.updateEmployee.EmployeeName;
                detailsInDb.DateOfBirth = request.updateEmployee.DateOfBirth;
                detailsInDb.Phone = request.updateEmployee.Phone;
                detailsInDb.Address = request.updateEmployee.Address;
                detailsInDb.EmployeeAge = request.updateEmployee.EmployeeAge;
                detailsInDb.BloodGroup = request.updateEmployee.BloodGroup;

                await employeeRepository.UpdateAsync(detailsInDb);
                return true;
            }
            return false;
        }
    }
}
