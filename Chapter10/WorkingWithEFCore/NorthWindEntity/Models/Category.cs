
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindEntity.Models;

public class Category
{
    // These properties map to columns in the database.
    public int CategoryId { get; set; } // The primary key. because of the Id
    [MaxLength(15)]
    public required string CategoryName { get; set; }
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    // Defines a navigation property for related rows.
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    // To enable developers to add products to a Category, we must
    // initialize the navigation property to an empty collection.
    // This also avoids an exception if we get a member like Count.

}
