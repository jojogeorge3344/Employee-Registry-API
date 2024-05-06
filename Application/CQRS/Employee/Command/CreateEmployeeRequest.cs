using Application.Models.EmployeeDtos;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.CQRS.Employee.Command
{
    public class CreateEmployeeRequest : IRequest<bool> 
    {
        public NewEmployeeDto EmployeeInsert { get; set; }
        public CreateEmployeeRequest(NewEmployeeDto employeeInsert)
        {
            this.EmployeeInsert = employeeInsert;
        }
    }

    public class CreateEmployeeRepositoryHandler : IRequestHandler<CreateEmployeeRequest, bool>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public CreateEmployeeRepositoryHandler(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            Domain.Models.Employee employee = mapper.Map<Domain.Models.Employee>(request.EmployeeInsert);
            await employeeRepository.AddNewAsync(employee);

            return true;
        }
    }
}
