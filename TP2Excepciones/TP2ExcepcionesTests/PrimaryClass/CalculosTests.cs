using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2Excepciones.PrimaryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2Excepciones.PrimaryClass.Tests
{
    [TestClass()]
    public class CalculosTests
    {
        [TestMethod()]
        public void DividirTest()
        {
            int resultadoEsperado = 0;
            Calculos oCalculo = new Calculos();
            int resultadoFinal = oCalculo.Dividir(10);

            Assert.AreNotEqual(resultadoEsperado, resultadoFinal);
        }

        [TestMethod()]
        public void Dividir2Test()
        {
            int resultadoEsperado = 2;
            Calculos oCalculo = new Calculos();
            int resultadoFinal = oCalculo.Dividir2(10, 5);
            Assert.AreEqual(resultadoEsperado, resultadoFinal);
        }
    }
}