using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppElComercio.Test
{
    [TestClass]
    public class Poblema01
    {
        [TestMethod]
        public void ChangeStringTest()
        {
            const String Entrada = "**Casa 52";
            const String Salida = "**Dbtb 52";

            var Resultado = ChangeString.build(Entrada);

            Assert.AreEqual(Salida, Resultado);
        }
    }
}
