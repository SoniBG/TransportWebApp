using System.ComponentModel.DataAnnotations;

namespace Common.Models;

public class OrderItemDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int GoodId { get; set; }

    public string? GoodName { get; set; }     
    
    public string? GoodSku { get; set; }      

    [Range(0.0, double.MaxValue)]
    public double Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }
}
