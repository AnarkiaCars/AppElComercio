using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppElComercio.Test
{
    [TestClass]
    public class Problema02
    {
        [TestMethod]
        public void CompleteRangeTest()
        {
            CompleteRange Prueba = new CompleteRange();
            int[] Entrada = new int[] { 4, 13, 23, 1 };
            int[] Salida = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };

            int[] Resultado = Prueba.build(Entrada);

            CollectionAssert.AreEqual(Salida, Resultado);
        }
    }
}
