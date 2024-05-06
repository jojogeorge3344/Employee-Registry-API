using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;

namespace Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services
              .AddAutoMapper(Assembly.GetExecutingAssembly())
              .AddMediatR(Assembly.GetExecutingAssembly())
              .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());        
        }
    }
}