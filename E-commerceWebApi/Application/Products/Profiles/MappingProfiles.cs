using AutoMapper;
using E_commerceWebApi.Application.Products.DTOs;
using E_commerceWebApi.Domain.Entities;

namespace E_commerceWebApi.Application.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
        }
    }
}
