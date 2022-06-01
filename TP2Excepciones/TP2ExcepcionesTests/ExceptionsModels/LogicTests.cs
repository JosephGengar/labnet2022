using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2Excepciones.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Excepciones.Exceptions.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod()]
        public void DevolverSumaNullTest()
        {
            Logic.DevolverSumaNull(null, 5);
        }
    }
}