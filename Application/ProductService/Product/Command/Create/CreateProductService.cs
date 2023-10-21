using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.Product.Command.Create.Dto;
using AutoMapper;

namespace Application.ProductService.Product.Command.Create;

public class CreateProductService:Command<CreateProductRequest>
{
    public CreateProductService(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateProductRequest request)
    {
        var category = DatabaseContext.Category.FirstOrDefault(x => x.Id == request.CategoryId);
        var product = Mapper.Map<CreateProductRequest,Domain.Product>(request);
        if (category != null) 
            product.Category = category;

        DatabaseContext.Product.Add(product);
        DatabaseContext.SaveChanges();
        return new Response();
    }
}