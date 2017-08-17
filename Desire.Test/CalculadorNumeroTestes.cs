using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesireWebApp.Models;
using System.Diagnostics;
using Desire.Core;
using Desire.Core.Itens;
using Desire.Core.Geradores;
using Desire.Core.Calculadores;
using System.Collections.Generic;
using System.Linq;

namespace Desire.Test
{
    class CalculadorNumeroTestes
    {
        CalculadorNumero calculador;
        
        //Testa a função CalculaPorcentagem para ver se ela retorna a porcentagem certa de um valor
        //Resultado esperado: dado 20% de 133, retornar 26 (arredondado de 26.6)
        [TestMethod]
        public void TesteCalculaPorcentagem()
        {
            calculador = new CalculadorNumero();
            long resultado = calculador.CalculaPorcentagem(20, 133);

            Assert.IsTrue(resultado == 26);
        }

        //Verifica o resultado da soma de dois ValorMag
        [TestMethod]
        public void TesteSomaValorMag()
        {
            calculador = new CalculadorNumero();
            ValorMag valorMagIgual1 = new ValorMag(50, 2);
            ValorMag valorMagIgual2 = new ValorMag(60, 2);
            ValorMag resultadoMagIgual = calculador.SomaValorMag(valorMagIgual1, valorMagIgual2);

            Assert.IsTrue(resultadoMagIgual.Valor == 11);
            Assert.IsTrue(resultadoMagIgual.Magnitude == 3);
            Assert.IsTrue(resultadoMagIgual.ValorReal == "110");

            ValorMag valorMagPerto1 = new ValorMag(50, 4);
            ValorMag valorMagPerto2 = new ValorMag(50, 3);
            ValorMag resultadoMagPerto = calculador.SomaValorMag(valorMagPerto1, valorMagPerto2);

            Assert.IsTrue(resultadoMagPerto.Valor == 55);
            Assert.IsTrue(resultadoMagPerto.Magnitude == 4);
            Assert.IsTrue(resultadoMagPerto.ValorReal == "5500");

            ValorMag valorMagLonge1 = new ValorMag(50, 3);
            ValorMag valorMagLonge2 = new ValorMag(50, 8);
            ValorMag resultadoMagLonge = calculador.SomaValorMag(valorMagLonge1, valorMagLonge2);

            Assert.IsTrue(resultadoMagLonge.Valor == 50);
            Assert.IsTrue(resultadoMagLonge.Magnitude == 8);
            Assert.IsTrue(resultadoMagLonge.ValorReal == "50000000");
        }

        //Verifica o resultado da multiplicação de dois ValorMag
        [TestMethod]
        public void TesteMultiplicaValorMagPorValorMag()
        {
            calculador = new CalculadorNumero();
            ValorMag valorMag1 = new ValorMag(10, 3);
            ValorMag valorMag2 = new ValorMag(10, 5);
            ValorMag resultado = calculador.MultiplicaValorMag(valorMag1, valorMag2);

            Assert.AreEqual(10, resultado.Valor);
            Assert.AreEqual(7, resultado.Magnitude);
            Assert.AreEqual("1000000", resultado.ValorReal);
        }

        //Verifica o resultado da divisão de dois ValorMag
        [TestMethod]
        public void TesteDivideValorMagPorValorMag()
        {
            calculador = new CalculadorNumero();
            ValorMag valorMag1 = new ValorMag(10, 5);
            ValorMag valorMag2 = new ValorMag(10, 3);
            ValorMag resultado = calculador.DivideValorMag(valorMag1, valorMag2);

            Assert.AreEqual(10, resultado.Valor);
            Assert.AreEqual(3, resultado.Magnitude);
            Assert.AreEqual("100", resultado.ValorReal);
        }

        //Verifica o resultado do método RetornaMaiorValorMag
        [TestMethod]
        public void TesteRetornaMaiorValorMag()
        {
            calculador = new CalculadorNumero();

            ValorMag num1 = new ValorMag(99, 5);
            ValorMag num2 = new ValorMag(26, 7);

            ValorMag resultado = calculador.RetornaMaiorValorMag(num1, num2);

            Assert.AreEqual(num2.ValorReal, resultado.ValorReal);
        }

        //Verifica o resultado do método RetornaMenorValorMag
        [TestMethod]
        public void TesteRetornaMenorValorMag()
        {
            calculador = new CalculadorNumero();

            ValorMag num1 = new ValorMag(99, 5);
            ValorMag num2 = new ValorMag(26, 7);

            ValorMag resultado = calculador.RetornaMenorValorMag(num1, num2);

            Assert.AreEqual(num1.ValorReal, resultado.ValorReal);
        }

        //Verifica o resultado do método RetornaMaiorValorMag utilizando uma lista
        [TestMethod]
        public void TesteRetornaMaiorValorMagDeLista()
        {
            calculador = new CalculadorNumero();
            List<ValorMag> lista = new List<ValorMag>
            {
                new ValorMag(10, 2),
                new ValorMag(15, 2),
                new ValorMag(35, 8),
                new ValorMag(10, 9),
                new ValorMag(99, 2),
                new ValorMag(58, 5),
                new ValorMag(20, 3)
            };

            ValorMag resultado = calculador.RetornaMaiorValorMag(lista);

            Assert.AreEqual(10, resultado.Valor);
            Assert.AreEqual(9, resultado.Magnitude);
            Assert.AreEqual("100000000", resultado.ValorReal);
        }

        //Verifica o resultado do método RetornaMaiorValorMag utilizando uma lista
        [TestMethod]
        public void TesteRetornaMenorValorMagDeLista()
        {
            calculador = new CalculadorNumero();
            List<ValorMag> lista = new List<ValorMag>
            {
                new ValorMag(10, 7),
                new ValorMag(15, 5),
                new ValorMag(35, 8),
                new ValorMag(10, 9),
                new ValorMag(99, 2),
                new ValorMag(58, 5),
                new ValorMag(20, 3)
            };

            ValorMag resultado = calculador.RetornaMenorValorMag(lista);

            Assert.AreEqual(99, resultado.Valor);
            Assert.AreEqual(2, resultado.Magnitude);
            Assert.AreEqual("99", resultado.ValorReal);
        }
    }
}
