using System;
using Bakery.Models.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bakery.Tests
{
  [TestClass]
  public class PriceTests
  {
    [TestMethod]
    public void GetPrice_ShouldAccuratelyPriceBreadLoaf_Int()
    {
      Bread loaf = new Bread();
      int expected  = 10;
      int actual = loaf.GetTotal(3);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetPrice_ShouldAccuratelyPastry_Int()
    {
      Pastry croissant = new Pastry();
      int expected = 8;
      int actual = croissant.GetTotal(5);

      Assert.AreEqual(expected, actual);
    }

  }
}