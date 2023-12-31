namespace Application.Common.Dto;

public class CategoryDto
{ 
    
    public string Name { get; set; }
    public string? ParentName { get; set; }
    public ICollection<StringObject> Children { get; set; } = new List<StringObject>();
}