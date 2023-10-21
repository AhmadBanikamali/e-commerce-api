namespace Domain;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Category> ChildCategories { get; set; } = new List<Category>();
    public Category? ParentCategory { get; set; }
    public int? ParentCategoryId { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}