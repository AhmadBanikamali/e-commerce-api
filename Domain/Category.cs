namespace Domain;

public class Category
{
    
    public string Name { get; set; }

    public ICollection<Category> ChildCategories { get; set; } = new List<Category>();
    public Category? ParentCategory { get; set; }

    public ICollection<Product> Products { get; set; }
}