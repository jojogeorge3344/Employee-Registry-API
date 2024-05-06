using Application.Models.EmployeeDtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.CQRS.Employee.Queries
{
    public class GetEmployeeListRequest : IRequest<List<GetEmployeeDto>>
    {
    }

    public class GetEmployeeListRequestHandler : IRequestHandler<GetEmployeeListRequest, List<GetEmployeeDto>> 
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public GetEmployeeListRequestHandler(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetEmployeeDto>> Handle(GetEmployeeListRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Models.Employee> listEmployee = await employeeRepository.GetAllAsync();

            if(listEmployee != null)
            {
                //map from GetEmployee to Employee
                List<GetEmployeeDto> employees = mapper.Map<List<GetEmployeeDto>>(listEmployee);
                return employees;
            }
            return null;
        }
    }
}
