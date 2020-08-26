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
                .ForMember(d => d.Brand, opt => opt.MapFrom(src => src.ProductBrand))
                 .ForMember(d => d.Type, opt => opt.MapFrom(src => src.ProductType));
            CreateMap<Repository.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<SliderItem, SliderDto>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Repository.Entities.OrderAggregate.Address>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.ItemOrdered.Image))
                .ForMember(d => d.Image, o => o.MapFrom<OrderItemUrlResolver>());


        }
    }
}
