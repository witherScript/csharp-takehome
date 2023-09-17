using System;


namespace Bakery.Models.Config
{
  public class Pastry : IProduct
  {
    public string Type { get; set; } = "Pastry";
    public string Name { get; set; } = "Croissant";
    public int Quantity{get; set;}

    public int GetTotal(int quantity)
    {
      int pricePerPastry = 2;
      int discountGroupSize = 4;
      int discountGroupPrice = 6;

      int discountGroups = quantity / discountGroupSize;
      int remainingPastries = quantity % discountGroupSize;

      int totalCost = (discountGroups * discountGroupPrice) + (remainingPastries * pricePerPastry);
      return totalCost;
    }
  }
}