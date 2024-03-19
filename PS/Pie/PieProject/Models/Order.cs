using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PieProject.Models;

public class Order
{
    [BindNever]
    public int OrderId { get; set; }
    public int OrderDetailId { get; set; }
    public List<OrderDetail> OrderDetails { get; init; } = [];
    [Display(Name = "First name"), StringLength(50)]
    public required string FirstName { get; set; }
    [Display(Name = "Last name"), StringLength(50)]
    public required string LastName { get; set; }
    [Display(Name = "Address Line 1"), StringLength(100)]
    public required string AddressLine1 { get; set; }
    [Display(Name = "Address Line 1"), StringLength(100)]
    public string? AddressLine2 { get; set; }
    [
        Required(ErrorMessage = "Please enter your zip code"),
        Display(Name = "Zip Code"),
        StringLength(10, MinimumLength = 4)
    ]
    public required string ZipCode { get; set; }
    [Required(ErrorMessage = "Please enter your city"), StringLength(50)]
    public required string City { get; set; }
    public string? State { get; set; }
    public required string Country { get; set; }
    [Display(Name = "Phone Number"),]
    public required string PhoneNumber { get; set; }
    [
        DataType(DataType.EmailAddress),
        RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])"),
    ]
    public required string Email { get; set; }
    [BindNever]
    public required decimal OrderTotal { get; set; }
    [BindNever]
    public DateTime OrderPlaced { get; } = DateTime.Now;
}
