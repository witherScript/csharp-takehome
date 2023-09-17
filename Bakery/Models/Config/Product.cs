using System;
namespace Bakery.Models.Config
{
  public interface IProduct
  {
    string Type{get; set;}
    string Name {get; set;}
    int Quantity{get; set;}

    int GetTotal(int quantity);
  }
}