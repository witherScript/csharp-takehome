using System;


namespace Bakery.Models
{
  public class Pastry : IProduct
  {
    public string Type { get; set; } = "Pastry";
    public string Name { get; set; } = "Croissant";
    public decimal Price { get; set; } = 0.00M;

    public decimal GetTotal(int quantity)
    {
      return 0.00M;
    }
  }
}