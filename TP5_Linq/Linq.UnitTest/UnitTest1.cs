using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Data;
using Linq.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linq.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCustomers3RTest()
        {
            using (var db  = new NorthWindContext())
            {
                var result = db.Customers.Where(c => c.Region == "WA").Take(3).ToList();
                Assert.IsTrue(result.Count() == 3);
            }
        }
        [TestMethod]
        public void GetProduct789()
        {
            using (var db = new NorthWindContext())
            {
                List<Products> ProductsList = new List<Products>();
                var query4 = db.Products.FirstOrDefault(p => p.CategoryID == 789);
                ProductsList.Add(query4);
                var result = ProductsList[0];
                Assert.IsNull(result);
            }
        }
    }
}
