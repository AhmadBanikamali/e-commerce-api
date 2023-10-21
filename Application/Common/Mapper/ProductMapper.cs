using Application.Common.Dto;
using Application.ProductService.Category.Command.Dto;
using Application.ProductService.Category.Query;
using Application.ProductService.Category.Query.Dto;
using Application.ProductService.Product.Command.Create.Dto;
using Application.ProductService.Product.Query.Single.Dto;
using AutoMapper;
using Domain;

namespace Application.Common.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ColorDto, Color>().ReverseMap();
        CreateMap<GuarantyDto, Guaranty>().ReverseMap();
        CreateMap<Category, CategoryDto>()
            .ForMember(x=>x.ParentName,y=>y.MapFrom(z=>z.ParentCategory==null?null:z.ParentCategory.Name))
            .ForMember(x=>x.Children,y=>y.MapFrom(z=>z.ChildCategories))
            .ReverseMap();


        CreateMap<ProductDetailDto, ProductDetail>().ReverseMap();

        CreateMap<CreateProductRequest, Product>().ReverseMap();
        CreateMap<Product, GetSingleProductResponse>();

        CreateMap<Category, StringObject>()
            .ForPath(x => x.Name, y => y.MapFrom(z => z.Name));
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, GetCategoriesResponse>()
            .ForPath(
                x => x.ParentName, y => y.MapFrom(
                    z => z.ParentCategory == null ? null : z.ParentCategory.Name)
            ).ForMember(
                x => x.Children, y => y.MapFrom(z => z.ChildCategories));
    }
}