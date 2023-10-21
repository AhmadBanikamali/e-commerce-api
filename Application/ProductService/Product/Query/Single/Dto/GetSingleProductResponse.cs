using Application.Common.Dto;

namespace Application.ProductService.Product.Query.Single.Dto;

public class GetSingleProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MiniDescription { get; set; }
    public string Description { get; set; }
    public ICollection<ColorDto> Colors { get; set; }
    public string Price { get; set; }
    public string Discount { get; set; }
    public ICollection<ProductDetailDto> ProductDetails { get; set; }
    public ICollection<GuarantyDto> Guaranties { get; set; }
    public CategoryDto Category { get; set; }
    
}