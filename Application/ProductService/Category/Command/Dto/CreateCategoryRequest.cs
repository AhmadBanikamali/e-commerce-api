namespace Application.ProductService.Category.Command.Dto;

public class CreateCategoryRequest
{
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
}