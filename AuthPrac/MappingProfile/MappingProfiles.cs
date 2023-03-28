using AuthPrac.Dto;
using AuthPrac.Entities;
using AutoMapper;

namespace AuthPrac.MappingProfile
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
