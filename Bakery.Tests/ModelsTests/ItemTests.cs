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
  }
}