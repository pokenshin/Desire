using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Desire.Core;
using Desire.Core.Itens;
using Desire.Util.Geradores;
using System.Collections.Generic;
using Desire.Core.Identidade;
using Desire.Core.Energias;
using Desire.Core.Ciencias;
using Desire.Core.Modificadores;

namespace Desire.Test.Util.Geradores
{
    [TestClass]
    public class GeradorTestes
    {
        Random rnd = new Random();
        //Vê se o método GeraNomeAleatorio está retornando strings do tamanho adequado
        //Resultado esperado: qualquer string maior que 9 caracteres e menor que 28
        [TestMethod]
        public void TesteGeraNomeAleatorio()
        {
            GeradorString genString = new GeradorString();
            string resultado = genString.GerarTamanhoEspecifico(3, 10, rnd);

            Assert.IsTrue(resultado.Length >= 3 && resultado.Length <= 10);
        }

        //Realiza 10 testes com ranges aleatórios para ver se o GeraInteiro retorna
        //números no range especificado
        [TestMethod]
        public void TesteGeraInteiro()
        {
            GeradorInteiro rng = new GeradorInteiro();
            Random rnd = new Random();
            int resultado;
            for (int i = 0; i < 10; i++)
            {
                int min = rnd.Next(0, 100);
                int max = min + rnd.Next(1, 100);

                resultado = rng.GerarEntre(min, max, rnd);
                Assert.IsTrue(resultado >= min && resultado <= max);
            }
        }

        //Teste o GeraInteiro para ver se ele está gerando números aleatórios em chamadas
        //Sucessivas
        [TestMethod]
        public void TesteGeraInteiroAleatorio()
        {
            GeradorInteiro rng = new GeradorInteiro();
            int resultado1;
            int resultado2;
            resultado1 = rng.GerarEntre(1, 1000, rnd);
            resultado2 = rng.GerarEntre(1, 1000, rnd);
            Assert.AreNotEqual(resultado1, resultado2);
        }

        //Teste as chances do GeraBoolean dentro de uma margem de +/- 10 pontos percentuais
        //Testendo com 70% de chances para true
        [TestMethod]
        public void TesteGeraBoolean()
        {
            GeradorBoolean gerador = new GeradorBoolean();
            int verdadeiros = 0;

            for (int i = 0; i < 100; i++)
            {
                if (gerador.GeraComChance(70, rnd))
                    verdadeiros = ++verdadeiros;
            }

            Assert.IsTrue(verdadeiros > 60);
        }

        //Teste os nomes do ser gerados pelo método GeraSerAleatorio
        //Debug para verificar qualidade dos nomes criados
        [TestMethod]
        public void TesteNomesGeraSerAleatorio()
        {
            GeradorSer gerador = new GeradorSer();
            Ser ser = gerador.Gerar(rnd);

            Assert.IsTrue(ser.Nome.Length > 2);
        }

        //Teste os nomes gerados pelo método GeraOrigem
        //Debug para verificar qualidade dos nomes criados
        [TestMethod]
        public void TesteNomesGeraOrigem()
        {
            GeradorOrigem gerador = new GeradorOrigem();
            Origem origem = gerador.Gerar(rnd);

            Assert.IsTrue(origem.Nome.Length > 0);
            Assert.IsTrue(origem.Plano.Nome.Length > 0);
            Assert.IsTrue(origem.Plano.Realidade.Nome.Length > 0);
        }

        //Teste a quantidade de energias gerada pela função GEraListaEnergias
        //Resultado esperado: Count entre 1 e 8
        [TestMethod]
        public void TesteQuantidadeGeraListaEnergias()
        {
            GeradorEnergia gerador = new GeradorEnergia();
            List<Energia> lista = gerador.GerarLista(5, rnd);

            Assert.IsTrue(lista.Count > 0 && lista.Count < 9);
        }

        //Teste a geração de atributos aleatórios pela função GeraAtributo
        //Resultado esperado: qualquer atributo com valores aleatórios
        [TestMethod]
        public void TesteGeraAtributo()
        {
            GeradorForca gerador = new GeradorForca();
            Forca forca = gerador.Gerar(rnd);

            Assert.IsNotNull(forca);
        }

        //Teste a geração de modificador aleatório pela função GeraModificadorInt
        //Resultado esperado: um modificador de uma propriedade aleatoria da classe ser, entre 1 e 99 e adição
        [TestMethod]
        public void TesteGeraModificadorInt()
        {
            GeradorModificador gerador = new GeradorModificador();
            Modificador modificador = gerador.Gerar(rnd);

            Assert.IsNotNull(modificador);
        }

        //Teste a geração de uma lista de modificadores positivos
        //Resultado esperado: uma lista com 2 ou mais elementos de Modificadores positivos
        [TestMethod]
        public void TesteGeraListaModificadores()
        {
            GeradorModificador gerador = new GeradorModificador();
            List<Modificador> lista = gerador.GerarLista(10, rnd);

            Assert.IsTrue(lista.Count > 0);
        }

        //Teste a geração de uma perícia gerada pela função GeraPericia
        //Reultado esperado: uma perícia com nome aleatório, descrição baseada no nome e efeitos baseados nos modificadores
        [TestMethod]
        public void TesteGeraPericia()
        {
            GeradorPericia gerador = new GeradorPericia();
            Pericia pericia = gerador.Gerar(rnd);

            Assert.IsNotNull(pericia);
        }

        //Teste a geração de uma lista de perícias aleatórias usando a função GeraListaPericias
        //Resultado esperado: uma lista maior que 0 e menor que 10
        [TestMethod]
        public void TesteGeraListaPericias()
        {
            GeradorPericia gerador = new GeradorPericia();
            List <Pericia> pericias = gerador.GerarLista(10, rnd);

            Assert.IsTrue(pericias.Count == 10);
        }

        //Teste a geração de uma Habilidade usando a função GeraHabilidade
        //Resultado esperado: uma habilidade aleatória com valores aleatórios associados a uma perícia aleatória
        [TestMethod]
        public void TesteGeraHabilidade()
        {
            GeradorHabilidade gerador = new GeradorHabilidade();
            Habilidade habilidade = gerador.Gerar(rnd);

            Assert.IsNotNull(habilidade);
        
        }

        //Teste a geração de uma área cientifica usando a função GeraAreaCientifica
        //Resultado esperado: uma area cientifica de uma ciencia aleatória
        [TestMethod]
        public void TesteGeraAreaCientifica()
        {
            GeradorAreaCientifica gerador = new GeradorAreaCientifica();
            AreaCientifica area = gerador.Gerar(rnd);

            Assert.IsNotNull(area);
        }

        //Teste a geração de uma ciência utilizando a função GeraCiencia
        //Resultado esperado: uma ciência com uma esfera científica aleatória
        [TestMethod]
        public void TesteGeraCiencia()
        {
            GeradorCiencia gerador = new GeradorCiencia();
            Ciencia ciencia = gerador.Gerar(rnd);

            Assert.IsNotNull(ciencia);
        }

        //Teste a geração de uma esfera cientifica utilizando a função GeraEsferaCientifica
        //Resultado esperado: uma esfera cientifica aleatória
        [TestMethod]
        public void TesteGeraEsferaCientifica()
        {
            GeradorEsfera gerador = new GeradorEsfera();
            Esfera esfera = gerador.Gerar(rnd);

            Assert.IsNotNull(esfera);
        }

        //Teste a geração de uma lista de habilidades utilizando a função GeraListaHabilidades
        //Resultado esperado: uma lista com pelo menos uma habilidade
        [TestMethod]
        public void TesteGeraListaHabilidades()
        {
            GeradorHabilidade gerador = new GeradorHabilidade();
            List<Habilidade> habilidades = gerador.GerarLista(10, rnd);

            Assert.IsTrue(habilidades.Count > 0);
        }

        //Testa a geração de origens (lugares)
        //Resultado esperado: uma origem com campos aleatórioas menos Id
        [TestMethod]
        public void TesteGeraOrigem()
        {
            GeradorOrigem gerador = new GeradorOrigem();
            Origem origem = gerador.Gerar(rnd);

            Assert.IsNotNull(origem);
        }

        //Testa a geração de uma lista de energias aleatórias
        //Resultado esperado: uma lista de energias com pelo menos um elemento.

        [TestMethod]
        public void TesteGeraListaEnergias()
        {
            GeradorEnergia gerador = new GeradorEnergia();
            List<Energia> energias = gerador.GerarLista(10, rnd);

            Assert.IsTrue(energias.Count > 0);
        }

        //Teste a geração de uma espécie completa com todos os atributos aleatórios
        //Resultado esperado: uma espécie completa com todos os campos menos Id preenchidos
        [TestMethod]
        public void TesteGeraEspecie()
        {
            GeradorEspecie gerador = new GeradorEspecie();
            Especie especie = gerador.Gerar(rnd);

            Assert.IsNotNull(especie);

        }

        //Testa a geração de uma classe completa com algumas perícias aleatórias
        //Resultado esperado: uma classe completa com todos os campos menos Id preenchidos
        [TestMethod]
        public void TesteGeraClasse()
        {
            GeradorClasse gerador = new GeradorClasse();
            Classe classe = gerador.Gerar(rnd);

            Assert.IsNotNull(classe);
        }

        //Testa a geração de uma lista de classes com todos os campos aleatórios
        //Resultado esperado: uma lista de classes com pelo menos uma classe
        [TestMethod]
        public void TesteGeraListaClasses()
        {
            GeradorClasse gerador = new GeradorClasse();
            List<Classe> classes = gerador.GerarLista(10, rnd);

            Assert.IsTrue(classes.Count == 10);
        }

        //Testa a geração de um material aleatório utilizando a função GeraMaterial
        //Resultado esperado: um material com valores aleatórios
        [TestMethod]
        public void TesteGeraMaterial()
        {
            GeradorMaterial gerador = new GeradorMaterial();
            Material material = gerador.Gerar(rnd);

            Assert.IsNotNull(material);
        }

        //Testa a geração de uma arma branca aleatória utilizando a função GeraItem
        //Resultado esperado: um objeto do tipo ArmaBranca com atributos aleatórios
        [TestMethod]
        public void TesteGeraItemArmaBranca()
        {
            GeradorArmaBranca gerador = new GeradorArmaBranca();
            ArmaBranca armaBranca = gerador.Gerar(rnd);

            Assert.IsNotNull(armaBranca);
        }

        //Testa a geração de um item aleatorio
        //Resultado esperado: um item aleatorio  com atributos aleatorios
        [TestMethod]
        public void TesteGeraItem()
        {
            GeradorItem gerador = new GeradorItem();
            Item item = gerador.Gerar(rnd);

            Assert.IsNotNull(item);
        }

        //Testa a geração de uma munição aleatória
        //Resultado esperado: uma munição aleatória com atributos aleatórios
        [TestMethod]
        public void TesteGeraMunicao()
        {
            GeradorMunicao gerador = new GeradorMunicao();
            Municao municao = gerador.Gerar(rnd);

            Assert.IsNotNull(municao);
        }

        //Testa a geração de uma lista aleatoria de equipamentos
        //Resultado esperado: uma lista de itens equipaveis
        [TestMethod]
        public void TesteGeraListaEquipamentos()
        {
            GeradorEquipamento gerador = new GeradorEquipamento();
            List<Equipamento> lista = gerador.GerarLista(10, rnd);

            Assert.IsTrue(lista.Count > 0);
        }

        //Testa a geração de uma lista de itens aleatórios
        //Resultado esperado: uma lista de itens aleatorios com atributos aleatórios
        [TestMethod]
        public void TesteGeraListaItens()
        {
            GeradorItem gerador = new GeradorItem();
            List<Item> lista = gerador.GerarLista(10, rnd);

            Assert.IsTrue(lista.Count > 0);
        }

        //Testa a geração de um rei aleatório utilizando a função GeraRei()
        //Resultado esperado: um rei com atributos aleatórios
        [TestMethod]
        public void TesteGeraRei()
        {
            GeradorRei gerador = new GeradorRei();
            Rei rei = gerador.Gerar(rnd);

            Assert.IsNotNull(rei);
        }

        //Testa a geração de uma lista de reis aleatórios usando a função GeraListaRei()
        //Resultado esperado: uma lista de Reis aleatórios
        [TestMethod]
        public void TesteGeraListaReis()
        {
            GeradorRei gerador = new GeradorRei();
            List<Rei> lista = gerador.GerarLista(10, rnd);

            Assert.IsNotNull(lista);
            Assert.IsTrue(lista.Count > 0);
        }

        //Testa a função GeraInteirosQueSomam que gera numeros aleatorios que no fim somam até um valor
        //Resultado esperado: 5 numeros aleatorios que quando somados dão 100
        [TestMethod]
        public void TesteGeraInteirosQueSomam()
        {
            GeradorInteiro gerador = new GeradorInteiro();
            int[] resultado = gerador.GerarInteirosQueSomam(5, 100, rnd);
            int soma = resultado[0] + resultado[1] + resultado[2] + resultado[3] + resultado[4];

            Assert.IsTrue(soma == 100);
        }

        //Testa a função GeraListaEspecies que gera especies aleatorias
        //Resultado esperado: uma lista com quantidade de itens maior que 0
        [TestMethod]
        public void TesteGeraListaEspecies()
        {
            GeradorEspecie gerador = new GeradorEspecie();
            List<Especie> lista = gerador.GerarLista(10, rnd);

            Assert.IsTrue(lista.Count > 0);

        }

        //Testa a função GeraLong para ver se ela está gerando números aleatórios longos
        //Resultado esperado: um númeroa leatório entre 1000000000 e 10000000000
        [TestMethod]
        public void TesteGeraLong()
        {
            GeradorLong gerador = new GeradorLong();
            long resultado = gerador.GerarEntre(1000000000, 10000000000, rnd);

            Assert.IsTrue(resultado >= 1000000000);
            Assert.IsTrue(resultado <= 10000000000);
        }

        //Testa a função GeraValorMag para ver se ela está gerando ValorMag dentro do intervalo
        //Resultado esperado: um ValorMag dentro do intervalo especificado
        [TestMethod]
        public void TesteGeraValorMag()
        {
            GeradorValorMag gerador = new GeradorValorMag();
            ValorMag valorMag1 = new ValorMag(10, 3);
            ValorMag valorMag2 = new ValorMag(10, 5);
            ValorMag resultado = gerador.GerarEntre(valorMag1, valorMag2, rnd);

            Assert.IsTrue(Convert.ToInt32(resultado.ValorReal)>= Convert.ToInt32(valorMag1.ValorReal));
            Assert.IsTrue(Convert.ToInt32(resultado.ValorReal) <= Convert.ToInt32(valorMag2.ValorReal));
        }

        //Testa a geração de uma Natureza válida
        [TestMethod]
        public void TesteGeraNatureza()
        {
            GeradorNatureza gerador = new GeradorNatureza();
            Natureza natureza = gerador.Gerar(rnd);

            Assert.IsNotNull(natureza.Apresentacao);
            Assert.IsNotNull(natureza.Concepcao);
            Assert.IsNotNull(natureza.Honra);
            Assert.IsNotNull(natureza.Moral);
            Assert.IsNotNull(natureza.Percepcao);
            Assert.IsNotNull(natureza.Personalidade);
        }

        //Testa a geração de uma Resposta válida
        [TestMethod]
        public void TesteGeraResposta()
        {
            GeradorResposta gerador = new GeradorResposta();
            Resposta reacao = gerador.Gerar(rnd);

            Assert.IsNotNull(reacao);
        }

        //Testa a geração de uma lista de resistências aleatória
        [TestMethod]
        public void TesteGeraResistencias()
        {
            GeradorResistencia gerador = new GeradorResistencia();

            List<Resistencia> lista = gerador.GerarLista(10, rnd);

            Assert.IsTrue(lista.Count > 0);
        }

    }
}
