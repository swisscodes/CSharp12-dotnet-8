using System.ComponentModel.DataAnnotations;


namespace Northwind.EntityModels;

public class Category
{
    public int CategoryId { get; set; }

    [Required, StringLength(15)]
    public string CategoryName { get; set; }

    public string? Description { get; set; }
}