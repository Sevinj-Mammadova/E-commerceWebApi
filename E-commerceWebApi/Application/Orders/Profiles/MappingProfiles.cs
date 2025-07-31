using AutoMapper;
using E_commerceWebApi.Application.Orders.Dtos;
using E_commerceWebApi.Domain.Entities;

namespace E_commerceWebApi.Application.Orders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, OrderDetailsDto>().ReverseMap();
        }
    }
}
