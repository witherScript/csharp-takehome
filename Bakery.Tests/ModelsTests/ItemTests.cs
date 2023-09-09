using Bakery.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Bakery.Tests
{
  [TestClass]
  public class ProductTests
  {
    [TestMethod]
    public void Bread_IsA_IProduct()
    {
      IProduct bread = new Bread();

      Assert.IsNotNull(bread);
    }

    [TestMethod]
    public void Bread_CreatesInstanceOf_Bread()
    {
      Bread myLoaf = new Bread();

      Assert.AreEqual(typeof(Bread), myLoaf.GetType());
    }

    [TestMethod]
    public void Pastry_IsA_Product()
    {
      IProduct pastry = new Pastry();

      Assert.IsNotNull(pastry);
    }
  }
}