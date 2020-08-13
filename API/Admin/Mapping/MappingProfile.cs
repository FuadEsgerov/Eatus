using Admin.Models.Shopping;
using AutoMapper;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();

        
        }
    }
}
