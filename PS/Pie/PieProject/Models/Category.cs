namespace PieProject.Models;

public class Category
{
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public string? Description { get; set; }
    public List<Pie> Pies { get; set; } = [];
}