using Application.Common.Dto;

namespace Application.ProductService.Category.Query.Dto;

public class GetCategoriesResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ParentName { get; set; }
    public ICollection<StringObject> Children { get; set; } = new List<StringObject>();
}

