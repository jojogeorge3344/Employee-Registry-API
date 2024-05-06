using Application.Repositories;
using Infrastructure.Cotexts;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public static class ServiceCollectionExtension
    {
public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
    IConfiguration configuration)
        {
            return services
                .AddTransient<IEmployeeRepository, EmployeeRepository>()
                .AddTransient<IJobDetailRepository, JobDetailsRepository>()
                .AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
