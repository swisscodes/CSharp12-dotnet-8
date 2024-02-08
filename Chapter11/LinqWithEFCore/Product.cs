using System.ComponentModel.DataAnnotations;  // To use [Column].
using System.ComponentModel.DataAnnotations.Schema;


namespace Northwind.EntityModels;
public class Product
{
    public int ProductId { get; set; }
    [Required]
    [StringLength(40)]
    public required string ProductName { get; set; }

    public int? SupplierId { get; set; }
    public int? CategoryId { get; set; }
    [StringLength(20)]
    public string? QuantityPerUnit { get; set; }
    // Required for SQL Server provider.
    [Column(TypeName = "money")]
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
    public bool Discontinued { get; set; }
}
