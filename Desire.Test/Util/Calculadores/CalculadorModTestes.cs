using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Desire.Util.Calculadores;
using Desire.Core;
using Desire.Core.Modificadores;
using Desire.Core.Ciencias;

namespace Desire.Test.Core
{
    [TestClass]
    public class CalculadorModTestes
    {
        Ser ser;

        //Testa a aplicação de um modificador de soma de valor mag
        [TestMethod]
        public void TesteAplicaModificadorModSomaValorMag()
        {
            ser = new Ser();
            CalculadorMod calcMod = new CalculadorMod();
            ModSomaValorMag modificador = new ModSomaValorMag()
            {
                Alvo = "BonusHP",
                Origem = "Teste",
                Valor = new ValorMag(25, 2)
            };

            ser.BonusHP = new ValorMag(10, 2);

            calcMod.AplicaModificador(modificador, ser);

            Assert.IsTrue(ser.BonusHP.ToString() == "35m2");
        }

        //Testa a remoção de um modificador de soma de valormag
        [TestMethod]
        public void TesteRemoveModificadorModSomaValorMag()
        {
            ser = new Ser();
            CalculadorMod calcMod = new CalculadorMod();
            ModSomaValorMag modificador = new ModSomaValorMag()
            {
                Alvo = "BonusHP",
                Origem = "Teste",
                Valor = new ValorMag(25, 2)
            };

            ser.BonusHP = new ValorMag(10, 2);

            calcMod.AplicaModificador(modificador, ser);

            calcMod.RemoveModificador(modificador, ser);

            Assert.IsTrue(ser.BonusHP.ToString() == "10m2");
        }

        //Testa a adição de um modificador que adiciona uma perícia
        [TestMethod]
        public void TesteAplicaModificadorModAdicionaPericia()
        {
            ser = new Ser();
            CalculadorMod calcMod = new CalculadorMod();
            Pericia pericia = new Pericia()
            {
                Nome = "Pericia 1"
            };
            ModAdicionaPericia modificador = new ModAdicionaPericia()
            {
                Alvo = pericia,
                Origem = "Teste"
            };

            calcMod.AplicaModificador(modificador, ser);

            Assert.IsTrue(ser.Pericias.Contains(pericia));
        }

        //Testa a adição de um modificador que remove uma perícia
        [TestMethod]
        public void TesteAplicaModificadorModRemovePericia()
        {
            ser = new Ser();
            CalculadorMod calcMod = new CalculadorMod();
            Pericia pericia = new Pericia()
            {
                Nome = "Pericia 1"
            };
            ser.Pericias.Add(pericia);

            ModRemovePericia modificador = new ModRemovePericia()
            {
                Alvo = pericia,
                Origem = "Teste"
            };

            calcMod.AplicaModificador(modificador, ser);

            Assert.IsTrue(!ser.Pericias.Contains(pericia));
        }

        //Testa a adição de um modificador que adiciona uma habilidade
        [TestMethod]
        public void TesteAplicaModificadorModAdicionaHabilidade()
        {
            ser = new Ser();
            CalculadorMod calcMod = new CalculadorMod();
            Habilidade habilidade = new Habilidade()
            {
                Id = 1
            };
            ModAdicionaHabilidade modificador = new ModAdicionaHabilidade()
            {
                Alvo = habilidade,
                Origem = "Teste"
            };

            calcMod.AplicaModificador(modificador, ser);

            Assert.IsTrue(ser.Habilidades.Contains(habilidade));
        }

        //Testa a adição de um modificador que remove uma habilidade
        [TestMethod]
        public void TesteAplicaModificadorModRemoveHabilidade()
        {
            ser = new Ser();
            CalculadorMod calcMod = new CalculadorMod();
            Habilidade habilidade = new Habilidade()
            {
                Id = 1
            };
            ser.Habilidades.Add(habilidade);

            ModRemoveHabilidade modificador = new ModRemoveHabilidade()
            {
                Alvo = habilidade,
                Origem = "Teste"
            };

            calcMod.AplicaModificador(modificador, ser);

            Assert.IsTrue(!ser.Habilidades.Contains(habilidade));
        }
    }
}
