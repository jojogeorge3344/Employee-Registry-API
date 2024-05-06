using Application.Repositories;
using MediatR;

namespace Application.CQRS.Employee.Command
{
    public class DeleteEmployeeRequest : IRequest<bool>
    {
        public int EmployeeId { get; set; }

        public DeleteEmployeeRequest(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }

    public class DeleteEmployeeRequestHandler : IRequestHandler<DeleteEmployeeRequest, bool>
    {
        private readonly IEmployeeRepository employeeRepository;

        public DeleteEmployeeRequestHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            Domain.Models.Employee employeeInDb = await employeeRepository.GetByIdAsync(request.EmployeeId);
            if(employeeInDb != null) 
            {
                await employeeRepository.PermanentDeleteAsync(employeeInDb);
                return true;
            }
            return false;
        }
    }
}
