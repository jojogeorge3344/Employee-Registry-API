using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cotexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {           
        }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<JobDetails> JobDetails => Set<JobDetails>();
    }
}
