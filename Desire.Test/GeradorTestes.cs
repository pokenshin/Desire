using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Desire.Core;
using Desire.Core.Itens;
using Desire.Core.Services;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Test
{
    [TestClass]
    public class GeradorTestes
    {
        Gerador gerador;
        
        //V� se o m�todo GeraNomeAleatorio est� retornando strings do tamanho adequado
        //Resultado esperado: qualquer string maior que 9 caracteres e menor que 28
        [TestMethod]
        public void TesteGeraNomeAleatorio()
        {
            gerador = new Gerador();
            string resultado = gerador.GeraNomeAleatorio(3, 10);

            Assert.IsTrue(resultado.Length >= 3 && resultado.Length <= 10);
        }

        //Realiza 10 testes com ranges aleat�rios para ver se o GeraInteiro retorna
        //n�meros no range especificado
        [TestMethod]
        public void TesteGeraInteiro()
        {
            gerador = new Gerador();
            Random rnd = new Random();
            int resultado;
            for (int i = 0; i < 10; i++)
            {
                int min = rnd.Next(0, 100);
                int max = min + rnd.Next(1, 100);

                resultado = gerador.GeraInteiro(min, max);
                Assert.IsTrue(resultado >= min && resultado <= max);
            }
        }

        //Teste o GeraInteiro para ver se ele est� gerando n�meros aleat�rios em chamadas
        //Sucessivas
        [TestMethod]
        public void TesteGeraInteiroAleatorio()
        {
            gerador = new Gerador();
            int resultado1;
            int resultado2;
            resultado1 = gerador.GeraInteiro(1, 1000);
            resultado2 = gerador.GeraInteiro(1, 1000);
            Assert.AreNotEqual(resultado1, resultado2);
        }

        //Teste as chances do GeraBoolean dentro de uma margem de +/- 10 pontos percentuais
        //Testendo com 70% de chances para true
        [TestMethod]
        public void TesteGeraBoolean()
        {
            gerador = new Gerador();
            int verdadeiros = 0;

            for (int i = 0; i < 100; i++)
            {
                if (gerador.GeraBoolean(70))
                    verdadeiros = ++verdadeiros;
            }

            Assert.IsTrue(verdadeiros > 60);
        }

        //Teste os nomes do ser gerados pelo m�todo GeraSerAleatorio
        //Debug para verificar qualidade dos nomes criados
        [TestMethod]
        public void TesteNomesGeraSerAleatorio()
        {
            gerador = new Gerador();
            Ser ser = gerador.GeraSerAleatorio();

            Assert.IsTrue(ser.Nome.Length > 2);
        }

        //Teste os nomes gerados pelo m�todo GeraOrigem
        //Debug para verificar qualidade dos nomes criados
        [TestMethod]
        public void TesteNomesGeraOrigem()
        {
            gerador = new Gerador();
            Origem origem = gerador.GeraOrigem();

            Assert.IsTrue(origem.Nome.Length > 0);
            Assert.IsTrue(origem.Plano.Nome.Length > 0);
            Assert.IsTrue(origem.Plano.Realidade.Nome.Length > 0);
        }

        //Teste a quantidade de energias gerada pela fun��o GEraListaEnergias
        //Resultado esperado: Count entre 1 e 8
        [TestMethod]
        public void TesteQuantidadeGeraListaEnergias()
        {
            gerador = new Gerador();
            List<Energia> lista = gerador.GeraListaEnergias();

            Assert.IsTrue(lista.Count > 0 && lista.Count < 9);
        }

        //Teste a gera��o de atributos aleat�rios pela fun��o GeraAtributo
        //Resultado esperado: qualquer atributo com valores aleat�rios
        [TestMethod]
        public void TesteGeraAtributo()
        {
            gerador = new Gerador();
            Forca forca = (Forca)gerador.GeraAtributo("For�a");

            Assert.IsNotNull(forca);
        }

        //Teste a gera��o de modificador aleat�rio pela fun��o GeraModificadorInt
        //Resultado esperado: um modificador de uma propriedade aleatoria da classe ser, entre 1 e 99 e adi��o
        [TestMethod]
        public void TesteGeraModificadorInt()
        {
            gerador = new Gerador();
            Modificador modificador = gerador.GeraModificadorInt("Teste", 0, '+');

            Assert.IsNotNull(modificador);
        }

        //Teste a gera��o de uma lista de modificadores positivos
        //Resultado esperado: uma lista com 2 ou mais elementos de Modificadores positivos
        [TestMethod]
        public void TesteGeraListaModificadores()
        {
            gerador = new Gerador();
            List<Modificador> lista = gerador.GeraListaModificadores("Teste", 0);

            Assert.IsTrue(lista.Count > 0);
        }

        //Teste a gera��o de uma per�cia gerada pela fun��o GeraPericia
        //Reultado esperado: uma per�cia com nome aleat�rio, descri��o baseada no nome e efeitos baseados nos modificadores
        [TestMethod]
        public void TesteGeraPericia()
        {
            gerador = new Gerador();
            Pericia pericia = gerador.GeraPericia();

            Assert.IsNotNull(pericia);
        }

        //Teste a gera��o de uma lista de per�cias aleat�rias usando a fun��o GeraListaPericias
        //Resultado esperado: uma lista maior que 0 e menor que 10
        [TestMethod]
        public void TesteGeraListaPericias()
        {
            gerador = new Gerador();
            List <Pericia> pericias = gerador.GeraListaPericias();

            Assert.IsTrue(pericias.Count > 0);
        }

        //Teste a gera��o de uma Habilidade usando a fun��o GeraHabilidade
        //Resultado esperado: uma habilidade aleat�ria com valores aleat�rios associados a uma per�cia aleat�ria
        [TestMethod]
        public void TesteGeraHabilidade()
        {
            gerador = new Gerador();
            Habilidade habilidade = gerador.GeraHabilidade();

            Assert.IsNotNull(habilidade);
        
        }

        //Teste a gera��o de uma �rea cientifica usando a fun��o GeraAreaCientifica
        //Resultado esperado: uma area cientifica de uma ciencia aleat�ria
        [TestMethod]
        public void TesteGeraAreaCientifica()
        {
            gerador = new Gerador();
            Area area = gerador.GeraAreaCientifica();

            Assert.IsNotNull(area);
        }

        //Teste a gera��o de uma ci�ncia utilizando a fun��o GeraCiencia
        //Resultado esperado: uma ci�ncia com uma esfera cient�fica aleat�ria
        [TestMethod]
        public void TesteGeraCiencia()
        {
            gerador = new Gerador();
            Ciencia ciencia = gerador.GeraCiencia();

            Assert.IsNotNull(ciencia);
        }

        //Teste a gera��o de uma esfera cientifica utilizando a fun��o GeraEsferaCientifica
        //Resultado esperado: uma esfera cientifica aleat�ria
        [TestMethod]
        public void TesteGeraEsferaCientifica()
        {
            gerador = new Gerador();
            Esfera esfera = gerador.GeraEsferaCientifica();

            Assert.IsNotNull(esfera);
        }

        //Teste a gera��o de uma lista de habilidades utilizando a fun��o GeraListaHabilidades
        //Resultado esperado: uma lista com pelo menos uma habilidade
        [TestMethod]
        public void TesteGeraListaHabilidades()
        {
            gerador = new Gerador();
            List<Habilidade> habilidades = gerador.GeraListaHabilidades(1, 10);

            Assert.IsTrue(habilidades.Count > 0);
        }

        //Testa a gera��o de origens (lugares)
        //Resultado esperado: uma origem com campos aleat�rioas menos Id
        [TestMethod]
        public void TesteGeraOrigem()
        {
            gerador = new Gerador();
            Origem origem = gerador.GeraOrigem();

            Assert.IsNotNull(origem);
        }

        //Testa a gera��o de uma lista de energias aleat�rias
        //Resultado esperado: uma lista de energias com pelo menos um elemento.

        [TestMethod]
        public void TesteGeraListaEnergias()
        {
            gerador = new Gerador();
            List<Energia> energias = gerador.GeraListaEnergias();

            Assert.IsTrue(energias.Count > 0);
        }

        //Teste a gera��o de uma esp�cie completa com todos os atributos aleat�rios
        //Resultado esperado: uma esp�cie completa com todos os campos menos Id preenchidos
        [TestMethod]
        public void TesteGeraEspecie()
        {
            gerador = new Gerador();
            Especie especie = gerador.GeraEspecie();

            Assert.IsNotNull(especie);

        }

        //Testa a gera��o de uma classe completa com algumas per�cias aleat�rias
        //Resultado esperado: uma classe completa com todos os campos menos Id preenchidos
        [TestMethod]
        public void TesteGeraClasse()
        {
            gerador = new Gerador();
            Classe classe = gerador.GeraClasse();

            Assert.IsNotNull(classe);
        }

        //Testa a gera��o de uma lista de classes com todos os campos aleat�rios
        //Resultado esperado: uma lista de classes com pelo menos uma classe
        [TestMethod]
        public void TesteGeraListaClasses()
        {
            gerador = new Gerador();
            List<Classe> classes = gerador.GeraListaClasses();

            Assert.IsTrue(classes.Count > 0);
        }

        //Testa a gera��o de um material aleat�rio utilizando a fun��o GeraMaterial
        //Resultado esperado: um material com valores aleat�rios
        [TestMethod]
        public void TesteGeraMaterial()
        {
            gerador = new Gerador();
            Material material = gerador.GeraMaterial();

            Assert.IsNotNull(material);
        }

        //Testa a gera��o de uma arma branca aleat�ria utilizando a fun��o GeraItem
        //Resultado esperado: um objeto do tipo ArmaBranca com atributos aleat�rios
        [TestMethod]
        public void TesteGeraItemArmaBranca()
        {
            gerador = new Gerador();
            ArmaBranca armaBranca = (ArmaBranca)gerador.GeraItem("ArmaBranca");

            Assert.IsNotNull(armaBranca);
        }

        //Testa a gera��o de um item aleatorio
        //Resultado esperado: um item aleatorio  com atributos aleatorios
        [TestMethod]
        public void TesteGeraItem()
        {
            gerador = new Gerador();
            Item item = gerador.GeraItem();

            Assert.IsNotNull(item);
        }

        //Testa a gera��o de uma muni��o aleat�ria
        //Resultado esperado: uma muni��o aleat�ria com atributos aleat�rios
        [TestMethod]
        public void TesteGeraMunicao()
        {
            gerador = new Gerador();
            Municao municao = gerador.GeraMunicao();

            Assert.IsNotNull(municao);
        }

        //Testa a gera��o de uma lista aleatoria de equipamentos
        //Resultado esperado: uma lista de itens equipaveis
        [TestMethod]
        public void TesteGeraListaEquipamentos()
        {
            gerador = new Gerador();
            List<Item> lista = gerador.GeraListaEquipamentos(5, 5);

            Assert.IsTrue(lista.Count > 0);
        }

        //Testa a gera��o de uma lista de itens aleat�rios
        //Resultado esperado: uma lista de itens aleatorios com atributos aleat�rios
        [TestMethod]
        public void TesteGeraListaItens()
        {
            gerador = new Gerador();
            List<Item> lista = gerador.GeraListaItens(gerador.GeraInteiro(1, 10));

            Assert.IsTrue(lista.Count > 0);
        }

        //Testa a gera��o de uma cor aleat�ria a partir da fun��o GeraCor()
        //Resultado esperado: uma cor aleat�ria a partir da lista definida dentro da classe Gerador
        [TestMethod]
        public void TesteGeraCor()
        {
            gerador = new Gerador();
            string cor = gerador.GeraCor();

            Assert.IsNotNull(cor);
            Assert.IsTrue(cor != "");
        }

        //Testa a gera��o de um rei aleat�rio utilizando a fun��o GeraRei()
        //Resultado esperado: um rei com atributos aleat�rios
        [TestMethod]
        public void TesteGeraRei()
        {
            gerador = new Gerador();
            Rei rei = gerador.GeraRei();

            Assert.IsNotNull(rei);
        }

        //Testa a gera��o de uma lista de reis aleat�rios usando a fun��o GeraListaRei()
        //Resultado esperado: uma lista de Reis aleat�rios
        [TestMethod]
        public void TesteGeraListaReis()
        {
            gerador = new Gerador();
            List<Rei> lista = gerador.GeraListaReis();

            Assert.IsNotNull(lista);
            Assert.IsTrue(lista.Count > 0);
        }

        //Testa a fun��o GeraInteirosQueSomam que gera numeros aleatorios que no fim somam at� um valor
        //Resultado esperado: 5 numeros aleatorios que quando somados d�o 100
        [TestMethod]
        public void TesteGeraInteirosQueSomam()
        {
            gerador = new Gerador();
            int[] resultado = gerador.GeraInteirosQueSomam(5, 100);
            int soma = resultado[0] + resultado[1] + resultado[2] + resultado[3] + resultado[4];

            Assert.IsTrue(soma == 100);
        }

        //Testa a fun��o GeraListaEspecies que gera especies aleatorias
        //Resultado esperado: uma lista com quantidade de itens maior que 0
        [TestMethod]
        public void TesteGeraListaEspecies()
        {
            gerador = new Gerador();
            List<Especie> lista = gerador.GeraListaEspecies();

            Assert.IsTrue(lista.Count > 0);

        }

        //Testa a fun��o GeraLong para ver se ela est� gerando n�meros aleat�rios longos
        //Resultado esperado: um n�meroa leat�rio entre 1000000000 e 10000000000
        [TestMethod]
        public void TesteGeraLong()
        {
            gerador = new Gerador();
            long resultado = gerador.GeraLong(1000000000, 10000000000);

            Assert.IsTrue(resultado >= 1000000000);
            Assert.IsTrue(resultado <= 10000000000);
        }

        //Testa a fun��o GeraValorMag para ver se ela est� gerando ValorMag dentro do intervalo
        //Resultado esperado: um ValorMag dentro do intervalo especificado
        [TestMethod]
        public void TesteGeraValorMag()
        {
            gerador = new Gerador();
            ValorMag valorMag1 = new ValorMag(10, 3);
            ValorMag valorMag2 = new ValorMag(10, 5);
            ValorMag resultado = gerador.GeraValorMag(valorMag1, valorMag2);

            Assert.IsTrue(Convert.ToInt32(resultado.ValorReal)>= Convert.ToInt32(valorMag1.ValorReal));
            Assert.IsTrue(Convert.ToInt32(resultado.ValorReal) <= Convert.ToInt32(valorMag2.ValorReal));
        }

        //Testa a gera��o de uma origem do poder v�lida
        [TestMethod]
        public void TesteGeraOrigemPoder()
        {
            gerador = new Gerador();

            Assert.IsNotNull(gerador.GeraOrigemPoder());
        }

        //Testa a gera��o de uma Natureza v�lida
        [TestMethod]
        public void TesteGeraNatureza()
        {
            gerador = new Gerador();
            Natureza natureza = gerador.GeraNatureza();

            Assert.IsNotNull(natureza.Apresentacao);
            Assert.IsNotNull(natureza.Concepcao);
            Assert.IsNotNull(natureza.Honra);
            Assert.IsNotNull(natureza.Moral);
            Assert.IsNotNull(natureza.Percepcao);
            Assert.IsNotNull(natureza.Personalidade);
        }

        //Testa a gera��o de uma Resposta v�lida
        [TestMethod]
        public void TesteGeraResposta()
        {
            gerador = new Gerador();
            Resposta reacao = gerador.GeraResposta();

            Assert.IsNotNull(reacao);
        }

        //Testa a gera��o de uma lista de resist�ncias aleat�ria
        [TestMethod]
        public void TesteGeraResistencias()
        {
            gerador = new Gerador();

            List<Resistencia> lista = gerador.GeraListaResistencias();

            Assert.IsTrue(lista.Count > 0);
        }

    }
}
