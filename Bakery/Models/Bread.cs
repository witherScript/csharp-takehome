using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Bread : IProduct
  {
    public string Type { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Bread()
    {
      this.Type = "Bread";
      this.Name = "Whole Wheat";
      this.Price = 2.99M;
    }

    public Bread(string type, string name, decimal price )
    {
      this.Type = type;
      this.Name = name;
      this.Price = price;
    }

    public decimal GetTotal(int quantity)
    {
      return 0.00M;
    }
  }
}