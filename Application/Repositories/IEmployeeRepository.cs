using Domain.Models;

namespace Application.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddNewAsync (Employee employee);
        Task UpdateAsync (Employee employee);
        Task DeleteAsync(Employee employee);
        Task<Employee> GetByIdAsync (int id);
        Task <List<Employee>> GetAllAsync();
        Task PermanentDeleteAsync(Employee employee);
    }
}
