using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MiniDescription { get; set; }
    public string Description { get; set; }
    public ICollection<Color> Colors { get; set; }
    public string Price { get; set; }
    public string Discount { get; set; }
    public ICollection<ProductDetail> ProductDetails { get; set; }
    public ICollection<Guaranty> Guaranties { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
}

