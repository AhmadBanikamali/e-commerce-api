using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.Command.Create.Dto;
using AutoMapper;
using Domain;

namespace Application.ProductService.Command.Create;

public class CreateProductService:Command<CreateProductRequest>
{
    public CreateProductService(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateProductRequest request)
    {
        DatabaseContext.Product.Add(Mapper.Map<CreateProductRequest,Product>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}