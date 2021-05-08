using AutoMapper;
using Nairobi.Application.Commands;
using Nairobi.Dtos;
using Nairobi.Entities;

namespace Nairobi.Mapping
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<CreateProductCommand, ProductDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
