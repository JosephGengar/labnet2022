using System;
using System.Linq;
using Entity.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllTest()
        {
            using (var Context = new NorthWindContext())
            {
                var result = Context.Territories.ToList();
                Assert.IsTrue(result.Count > 0);
                //acordarse de colocar en app.config el connectionstring..
            }
        }
        [TestMethod()]
        public void GetOneTest()
        {
            using (var Context = new NorthWindContext())
            {
                //Corroborrar q el id extraido corresponde con el solicitado y no me trae cualquier cosa
                int id = 2;
                var result = Context.Shippers.Find(id);
                Assert.AreEqual(id, result.ShipperID);
            }
        }
    }
}

