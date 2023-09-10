using System;
using System.Collections.Generic;

namespace Bakery.Models.Config
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
    }

    public int GetTotal(int quantity)
    {
      int pricePerLoaf = 5;
      int pairQuantity = quantity / 3;
      int remainingLoaves = quantity % 3;

      int totalCost = (pairQuantity * 2 * pricePerLoaf) + (remainingLoaves * pricePerLoaf);
      return totalCost;
    }
  }
}