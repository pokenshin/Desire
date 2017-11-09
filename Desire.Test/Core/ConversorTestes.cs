using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Desire.Util;
using Desire.Core;
using Desire.Core.Identidade;


namespace Desire.Test.Core
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

        //Testa a função StringParaValorMag para números positivos menores que 1
        //Resultado esperado: 10m0
        [TestMethod]
        public void TesteStringParaValorMag()
        {
            conversor = new Conversor();
            string numero = "584797,5683";
            int valor = 58;
            int mag = 6;
            ValorMag resultado = conversor.StringParaValorMag(numero);

            Assert.AreEqual(valor, resultado.Valor);
            Assert.AreEqual(mag, resultado.Magnitude);
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
