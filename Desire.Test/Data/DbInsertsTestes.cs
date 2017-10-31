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
    public class DbInsertsTestes
    {
        //Testa a inserção de um atributo de força
        [TestMethod]
        public void TesteInsertForca()
        {
            DbInserts dbInserts = new DbInserts();
            GeradorForca geradorForca = new GeradorForca();
            Random rnd = new Random();

            dbInserts.InsereForca(geradorForca.Gerar(rnd));
        }
    }
}
