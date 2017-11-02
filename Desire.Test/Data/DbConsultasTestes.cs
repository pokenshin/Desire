using Microsoft.VisualStudio.TestTools.UnitTesting;
using Desire.Core;
using Desire.Core.Util.Geradores;
using Desire.Data.Operacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Test.Data
{
    [TestClass]
    public class DbConsultasTestes
    {
        //Testa a consulta de uma força baseada nos pontos passados
        [TestMethod]
        public void TesteRetornaForca()
        {
            DbConsultas dbConsultas = new DbConsultas();
            Forca resultado = dbConsultas.RetornaForca(10);

            Assert.AreEqual(resultado.Classe, "N");
            Assert.AreEqual(resultado.Pontos, 10);
        }

        //Testa a consulta de uma matéria baseada nos pontos passados
        [TestMethod]
        public void TesteRetornaMateria()
        {
            DbConsultas dbConsultas = new DbConsultas();
            Materia resultado = dbConsultas.RetornaMateria(10);

            Assert.AreEqual(resultado.Classe, "N");
            Assert.AreEqual(resultado.Pontos, 10);
        }

        //Testa a consulta de uma Destreza baseada nos pontos passados
        [TestMethod]
        public void TesteRetornaDestreza()
        {
            DbConsultas dbConsultas = new DbConsultas();
            Destreza resultado = dbConsultas.RetornaDestreza(10);

            Assert.AreEqual(resultado.Classe, "N");
            Assert.AreEqual(resultado.Pontos, 10);
        }

        //Testa a consulta de uma Intelecto baseada nos pontos passados
        [TestMethod]
        public void TesteRetornaIntelecto()
        {
            DbConsultas dbConsultas = new DbConsultas();
            Intelecto resultado = dbConsultas.RetornaIntelecto(10);

            Assert.AreEqual(resultado.Classe, "N");
            Assert.AreEqual(resultado.Pontos, 10);
        }

        //Testa a consulta de uma Criatividade baseada nos pontos passados
        [TestMethod]
        public void TesteRetornaCriatividade()
        {
            DbConsultas dbConsultas = new DbConsultas();
            Criatividade resultado = dbConsultas.RetornaCriatividade(10);

            Assert.AreEqual(resultado.Classe, "N");
            Assert.AreEqual(resultado.Pontos, 10);
        }

        //Testa a consulta de uma Ideia baseada nos pontos passados
        [TestMethod]
        public void TesteRetornaIdeia()
        {
            DbConsultas dbConsultas = new DbConsultas();
            Ideia resultado = dbConsultas.RetornaIdeia(10);

            Assert.AreEqual(resultado.Classe, "N");
            Assert.AreEqual(resultado.Pontos, 10);
        }

        //Testa a consulta de uma Ideia baseada nos pontos passados
        [TestMethod]
        public void TesteRetornaExistencia()
        {
            DbConsultas dbConsultas = new DbConsultas();
            Existencia resultado = dbConsultas.RetornaExistencia(10);

            Assert.AreEqual(resultado.Classe, "N");
            Assert.AreEqual(resultado.Pontos, 10);
        }

        //Testa a consulta de uma lista de força
        [TestMethod]
        public void TesteRetornaListaForca()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Forca> resultado = dbConsultas.RetornaTabelaForca();

            Assert.IsNotNull(resultado);
        }

        //Testa a consulta de uma lista de matéria
        [TestMethod]
        public void TesteRetornaTabelaMateria()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Materia> resultado = dbConsultas.RetornaTabelaMateria();

            Assert.IsNotNull(resultado);
        }

        //Testa a consulta de uma lista de destreza
        [TestMethod]
        public void TesteRetornaTabelaDestreza()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Destreza> resultado = dbConsultas.RetornaTabelaDestreza();

            Assert.IsNotNull(resultado);
        }

        //Testa a consulta de uma lista de Intelecto
        [TestMethod]
        public void TesteRetornaTabelaIntelecto()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Intelecto> resultado = dbConsultas.RetornaTabelaIntelecto();

            Assert.IsNotNull(resultado);
        }

        //Testa a consulta de uma lista de Criatividade
        [TestMethod]
        public void TesteRetornaTabelaCriatividade()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Criatividade> resultado = dbConsultas.RetornaTabelaCriatividade();

            Assert.IsNotNull(resultado);
        }

        //Testa a consulta de uma lista de Idéia
        [TestMethod]
        public void TesteRetornaTabeladeia()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Ideia> resultado = dbConsultas.RetornaTabelaIdeia();

            Assert.IsNotNull(resultado);
        }

        //Testa a consulta de uma lista de Existencia
        [TestMethod]
        public void TesteRetornaTabelaExistencia()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Existencia> resultado = dbConsultas.RetornaTabelaExistencia();

            Assert.IsNotNull(resultado);
        }
    }
}
