using Admin.Models.Shopping;
using AutoMapper;
using Repository.Entities;
using Repository.Entities.OrderAggregate;
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
            CreateMap<ProductBrand, BrandViewModel>();
            CreateMap<BrandViewModel, ProductBrand>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();

        }
    }
}
