using Application.Common;
using Application.Common.BaseDto;
using Application.Common.CQRS;
using Application.ProductService.Category.Command.Dto;
using AutoMapper;

namespace Application.ProductService.Category.Command;

public class CreateCategoryService : Command<CreateCategoryRequest>
{
    public CreateCategoryService(IDatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
    {
    }

    public override Response Execute(CreateCategoryRequest request)
    {
        DatabaseContext.Category.Add(Mapper.Map<Domain.Category>(request));
        DatabaseContext.SaveChanges();
        return new Response();
    }
}