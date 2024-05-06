using Application.Models.EmployeeDtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.CQRS.Employee.Queries
{
    public class GetEmployeeRequestByIdRequest : IRequest<GetEmployeeDto>
    {
        public int EmployeeId { get; set; }

        public GetEmployeeRequestByIdRequest(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
    public class GetEmployeeRequestByIdRequestHandler : IRequestHandler<GetEmployeeRequestByIdRequest, GetEmployeeDto>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public GetEmployeeRequestByIdRequestHandler(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public async Task<GetEmployeeDto> Handle(GetEmployeeRequestByIdRequest request, CancellationToken cancellationToken)
        {
          var employeeInDb = await employeeRepository.GetByIdAsync(request.EmployeeId);
            
            if(employeeInDb != null)
            {
                //mapping from employee to getemployee
                GetEmployeeDto getEmployee = mapper.Map<GetEmployeeDto>(employeeInDb);
                return getEmployee;
            }
            return null;
        }
    }
}
