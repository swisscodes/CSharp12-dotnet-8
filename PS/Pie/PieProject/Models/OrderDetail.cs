namespace PieProject.Models;

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public required Order Order { get; set; }
    public int PieId { get; set; }
    public required Pie Pie { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }

}