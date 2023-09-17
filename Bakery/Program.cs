using System;
using Bakery.Models.UserInterfaceModels;
using Bakery.Models;

namespace Bakery
{
  public class Program
  {
    static void Main()
    {
      Start();

    }
    static void Start()
    {
      Banner newInteraction = new Banner();
      Banner.DisplayOnStart();
    }
  }
}