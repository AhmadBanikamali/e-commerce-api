using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.Product.Query.Single.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductService.Product.Query.Single;

public class GetSingleProductService:Query<GetSingleProductRequest,GetSingleProductResponse>
{
    public GetSingleProductService(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response<GetSingleProductResponse> Execute(GetSingleProductRequest request)
    {
        var product = DatabaseContext.Product.Include(
                x => x.Category).ThenInclude(x => x.ChildCategories)
            .Include(x => x.Colors)
            .Include(x => x.Guaranties)
            .Include(x => x.ProductDetails).FirstOrDefault(x => x.Id == request.Id);


        return new Response<GetSingleProductResponse>()
        {
            Data = Mapper.Map<GetSingleProductResponse>(product)
        };
    }
}