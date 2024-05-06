using Application.Repositories;
using Domain.Models;
using Infrastructure.Cotexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext dbconnection;
        public EmployeeRepository(ApplicationDbContext dbconnection)//context
        {
            this.dbconnection = dbconnection;
        }
        public async Task AddNewAsync(Employee employee)
        {
            await dbconnection.AddAsync(employee);
            await dbconnection.SaveChangesAsync();
        }

        public Task DeleteAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await dbconnection.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await dbconnection.Employees
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task PermanentDeleteAsync(Employee employee)
        {
            dbconnection.Employees.Remove(employee);
            await dbconnection.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            dbconnection.Employees.Update(employee);
            await dbconnection.SaveChangesAsync();
        }
    }
}