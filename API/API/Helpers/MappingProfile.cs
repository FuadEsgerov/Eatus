using API.Dtos;
using AutoMapper;
using Repository.Entities;
using Repository.Entities.OrderAggregate;
using System.Collections.Generic;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
       
                 CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name));
            CreateMap<Repository.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Repository.Entities.OrderAggregate.Address>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());


        }
    }
}
