using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.Common.Extension;
using Application.ProductService.Category.Query.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductService.Category.Query;

public class GetCategoriesService : PaginatedQuery<GetCategoriesRequest, GetCategoriesResponse>
{
    public GetCategoriesService(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override PaginatedResponse<GetCategoriesResponse> Execute(GetCategoriesRequest request)
    {
        var categories = DatabaseContext.Category
            .Include(x => x.ChildCategories)
            
            .PagedResult(request.PageNumber, request.PageSize)
            .ToList();
        return new PaginatedResponse<GetCategoriesResponse>()
        {
            Data = categories.Select(x => Mapper.Map<GetCategoriesResponse>(x)),
            PageNumber = request.PageNumber,
        };
    }
}