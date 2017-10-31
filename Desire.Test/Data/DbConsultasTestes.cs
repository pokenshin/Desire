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
            List<Forca> resultado = dbConsultas.RetornaListaForca();

            Assert.IsNotNull(resultado);
        }
    }
}
