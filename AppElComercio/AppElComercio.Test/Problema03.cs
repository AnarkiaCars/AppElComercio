using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppElComercio.Test
{
    [TestClass]
    public class Problema03
    {
        [TestMethod]
        public void MoneyPartsTest()
        {
            MoneyParts Prueba = new MoneyParts();
            Decimal Entrada = 0.2m;
            Decimal[][] Salida = new Decimal[4][];
            Salida[0] = new Decimal[] { 0.05m, 0.05m, 0.05m, 0.05m };
            Salida[1] = new Decimal[] { 0.1m, 0.05m, 0.05m };
            Salida[2] = new Decimal[] { 0.1m, 0.1m };
            Salida[3] = new Decimal[] { 0.2m };

            var Resultado = Prueba.build(Entrada);
            //El resultado es correcto.
            CollectionAssert.AreEqual(Salida, Resultado,"Pruebas");
        }
    }
}
