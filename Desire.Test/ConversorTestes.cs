using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Util;
using Desire.Core;
using Desire.Core.Identidade;


namespace Desire.Test
{
    [TestClass]
    public class ConversorTestes
    {
        Conversor conversor;
        //Testa a função ValorMagParaString para ver se a está convertendo corretamente
        //Resultado esperado: dado 25 em magnitude 10, retornar 2500000000
        [TestMethod]
        public void TesteValorMagParaString()
        {
            conversor = new Conversor();

            Assert.AreEqual("2500000000", conversor.ValorMagParaString(25, 10));
        }

        //Testa a função LongParaValorMag para ver se está convertendo corretamente
        //Resultado esperado: dado 2500000000, retornar 25 na posição 0 e 10 na posição 1
        [TestMethod]
        public void TesteLongParaValorMag()
        {
            conversor = new Conversor();
            ValorMag resultado = conversor.StringParaValorMag("2500000000");

            Assert.AreEqual(25, resultado.Valor);
            Assert.AreEqual(10, resultado.Magnitude);
        }
    }
}
