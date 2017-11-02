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
        //Testa a inserção de um atributo de força
        [TestMethod]
        public void TesteRetornaListaForca()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Forca> resultado = dbConsultas.RetornaTabelaForca();

            Assert.IsNotNull(resultado);
        }

        //Testa a inserção de um atributo de matéria
        [TestMethod]
        public void TesteRetornaTabelaMateria()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Materia> resultado = dbConsultas.RetornaTabelaMateria();

            Assert.IsNotNull(resultado);
        }

        //Testa a inserção de um atributo de destreza
        [TestMethod]
        public void TesteRetornaTabelaDestreza()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Destreza> resultado = dbConsultas.RetornaTabelaDestreza();

            Assert.IsNotNull(resultado);
        }

        //Testa a inserção de um atributo de Intelecto
        [TestMethod]
        public void TesteRetornaTabelaIntelecto()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Intelecto> resultado = dbConsultas.RetornaTabelaIntelecto();

            Assert.IsNotNull(resultado);
        }

        //Testa a inserção de um atributo de Criatividade
        [TestMethod]
        public void TesteRetornaTabelaCriatividade()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Criatividade> resultado = dbConsultas.RetornaTabelaCriatividade();

            Assert.IsNotNull(resultado);
        }

        //Testa a inserção de um atributo de Idéia
        [TestMethod]
        public void TesteRetornaTabeladeia()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Ideia> resultado = dbConsultas.RetornaTabelaIdeia();

            Assert.IsNotNull(resultado);
        }

        //Testa a inserção de um atributo de Existencia
        [TestMethod]
        public void TesteRetornaTabelaExistencia()
        {
            DbConsultas dbConsultas = new DbConsultas();
            List<Existencia> resultado = dbConsultas.RetornaTabelaExistencia();

            Assert.IsNotNull(resultado);
        }
    }
}
