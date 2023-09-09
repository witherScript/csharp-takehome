using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public interface IProduct
  {
    string Type{get; set;}
    string Name {get; set;}
    decimal Price {get; set;}  

    decimal GetTotal(int quantity);
  }
}