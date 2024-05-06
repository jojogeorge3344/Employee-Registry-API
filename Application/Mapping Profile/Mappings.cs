using Application.Models.EmployeeDtos;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping_Profile
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<NewEmployeeDto, Employee>();
            CreateMap<Employee, GetEmployeeDto>();
        }
    }
}
