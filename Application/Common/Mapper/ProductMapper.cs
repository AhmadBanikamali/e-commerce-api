using Application.Common.Dto;
using Application.ProductService.Command.Create.Dto;
using AutoMapper;
using Domain;

namespace Application.Common.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ColorDto, Color>().ReverseMap();
        CreateMap<GuarantyDto, Guaranty>().ReverseMap();
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<ProductDetailDto, ProductDetail>().ReverseMap();
        
        CreateMap<CreateProductRequest, Product>().ReverseMap();
    }   
}