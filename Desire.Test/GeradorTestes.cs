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
        
        //Vê se o método GeraNomeAleatorio está retornando strings do tamanho adequado
        //Resultado esperado: qualquer string maior que 9 caracteres e menor que 28
        [TestMethod]
        public void TesteGeraNomeAleatorio()
        {
            gerador = new Gerador();
            string resultado = gerador.GeraNomeAleatorio(3, 10);

            Assert.IsTrue(resultado.Length >= 3 && resultado.Length <= 10);
        }

        //Realiza 10 testes com ranges aleatórios para ver se o GeraInteiro retorna
        //números no range especificado
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

        //Teste o GeraInteiro para ver se ele está gerando números aleatórios em chamadas
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

        //Teste os nomes do ser gerados pelo método GeraSerAleatorio
        //Debug para verificar qualidade dos nomes criados
        [TestMethod]
        public void TesteNomesGeraSerAleatorio()
        {
            gerador = new Gerador();
            Ser ser = gerador.GeraSerAleatorio();

            Assert.IsTrue(ser.Nome.Length > 2);
        }

        //Teste os nomes gerados pelo método GeraOrigem
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

        //Teste a quantidade de energias gerada pela função GEraListaEnergias
        //Resultado esperado: Count entre 1 e 8
        [TestMethod]
        public void TesteQuantidadeGeraListaEnergias()
        {
            gerador = new Gerador();
            List<Energia> lista = gerador.GeraListaEnergias();

            Assert.IsTrue(lista.Count > 0 && lista.Count < 9);
        }

        //Teste a geração de atributos aleatórios pela função GeraAtributo
        //Resultado esperado: qualquer atributo com valores aleatórios
        [TestMethod]
        public void TesteGeraAtributo()
        {
            gerador = new Gerador();
            Forca forca = (Forca)gerador.GeraAtributo("Força");

            Assert.IsNotNull(forca);
        }

        //Teste a geração de modificador aleatório pela função GeraModificadorInt
        //Resultado esperado: um modificador de uma propriedade aleatoria da classe ser, entre 1 e 99 e adição
        [TestMethod]
        public void TesteGeraModificadorInt()
        {
            gerador = new Gerador();
            Modificador modificador = gerador.GeraModificadorInt("Teste", 0, '+');

            Assert.IsNotNull(modificador);
        }

        //Teste a geração de uma lista de modificadores positivos
        //Resultado esperado: uma lista com 2 ou mais elementos de Modificadores positivos
        [TestMethod]
        public void TesteGeraListaModificadores()
        {
            gerador = new Gerador();
            List<Modificador> lista = gerador.GeraListaModificadores("Teste", 0);

            Assert.IsTrue(lista.Count > 0);
        }

        //Teste a geração de uma perícia gerada pela função GeraPericia
        //Reultado esperado: uma perícia com nome aleatório, descrição baseada no nome e efeitos baseados nos modificadores
        [TestMethod]
        public void TesteGeraPericia()
        {
            gerador = new Gerador();
            Pericia pericia = gerador.GeraPericia();

            Assert.IsNotNull(pericia);
        }

        //Teste a geração de uma lista de perícias aleatórias usando a função GeraListaPericias
        //Resultado esperado: uma lista maior que 0 e menor que 10
        [TestMethod]
        public void TesteGeraListaPericias()
        {
            gerador = new Gerador();
            List <Pericia> pericias = gerador.GeraListaPericias();

            Assert.IsTrue(pericias.Count > 0);
        }

        //Teste a geração de uma Habilidade usando a função GeraHabilidade
        //Resultado esperado: uma habilidade aleatória com valores aleatórios associados a uma perícia aleatória
        [TestMethod]
        public void TesteGeraHabilidade()
        {
            gerador = new Gerador();
            Habilidade habilidade = gerador.GeraHabilidade();

            Assert.IsNotNull(habilidade);
        
        }

        //Teste a geração de uma área cientifica usando a função GeraAreaCientifica
        //Resultado esperado: uma area cientifica de uma ciencia aleatória
        [TestMethod]
        public void TesteGeraAreaCientifica()
        {
            gerador = new Gerador();
            Area area = gerador.GeraAreaCientifica();

            Assert.IsNotNull(area);
        }

        //Teste a geração de uma ciência utilizando a função GeraCiencia
        //Resultado esperado: uma ciência com uma esfera científica aleatória
        [TestMethod]
        public void TesteGeraCiencia()
        {
            gerador = new Gerador();
            Ciencia ciencia = gerador.GeraCiencia();

            Assert.IsNotNull(ciencia);
        }

        //Teste a geração de uma esfera cientifica utilizando a função GeraEsferaCientifica
        //Resultado esperado: uma esfera cientifica aleatória
        [TestMethod]
        public void TesteGeraEsferaCientifica()
        {
            gerador = new Gerador();
            Esfera esfera = gerador.GeraEsferaCientifica();

            Assert.IsNotNull(esfera);
        }

        //Teste a geração de uma lista de habilidades utilizando a função GeraListaHabilidades
        //Resultado esperado: uma lista com pelo menos uma habilidade
        [TestMethod]
        public void TesteGeraListaHabilidades()
        {
            gerador = new Gerador();
            List<Habilidade> habilidades = gerador.GeraListaHabilidades(1, 10);

            Assert.IsTrue(habilidades.Count > 0);
        }

        //Testa a geração de origens (lugares)
        //Resultado esperado: uma origem com campos aleatórioas menos Id
        [TestMethod]
        public void TesteGeraOrigem()
        {
            gerador = new Gerador();
            Origem origem = gerador.GeraOrigem();

            Assert.IsNotNull(origem);
        }

        //Testa a geração de uma lista de energias aleatórias
        //Resultado esperado: uma lista de energias com pelo menos um elemento.

        [TestMethod]
        public void TesteGeraListaEnergias()
        {
            gerador = new Gerador();
            List<Energia> energias = gerador.GeraListaEnergias();

            Assert.IsTrue(energias.Count > 0);
        }

        //Teste a geração de uma espécie completa com todos os atributos aleatórios
        //Resultado esperado: uma espécie completa com todos os campos menos Id preenchidos
        [TestMethod]
        public void TesteGeraEspecie()
        {
            gerador = new Gerador();
            Especie especie = gerador.GeraEspecie();

            Assert.IsNotNull(especie);

        }

        //Testa a geração de uma classe completa com algumas perícias aleatórias
        //Resultado esperado: uma classe completa com todos os campos menos Id preenchidos
        [TestMethod]
        public void TesteGeraClasse()
        {
            gerador = new Gerador();
            Classe classe = gerador.GeraClasse();

            Assert.IsNotNull(classe);
        }

        //Testa a geração de uma lista de classes com todos os campos aleatórios
        //Resultado esperado: uma lista de classes com pelo menos uma classe
        [TestMethod]
        public void TesteGeraListaClasses()
        {
            gerador = new Gerador();
            List<Classe> classes = gerador.GeraListaClasses();

            Assert.IsTrue(classes.Count > 0);
        }

        //Testa a geração de um material aleatório utilizando a função GeraMaterial
        //Resultado esperado: um material com valores aleatórios
        [TestMethod]
        public void TesteGeraMaterial()
        {
            gerador = new Gerador();
            Material material = gerador.GeraMaterial();

            Assert.IsNotNull(material);
        }

        //Testa a geração de uma arma branca aleatória utilizando a função GeraItem
        //Resultado esperado: um objeto do tipo ArmaBranca com atributos aleatórios
        [TestMethod]
        public void TesteGeraItemArmaBranca()
        {
            gerador = new Gerador();
            ArmaBranca armaBranca = (ArmaBranca)gerador.GeraItem("ArmaBranca");

            Assert.IsNotNull(armaBranca);
        }

        //Testa a geração de um item aleatorio
        //Resultado esperado: um item aleatorio  com atributos aleatorios
        [TestMethod]
        public void TesteGeraItem()
        {
            gerador = new Gerador();
            Item item = gerador.GeraItem();

            Assert.IsNotNull(item);
        }

        //Testa a geração de uma munição aleatória
        //Resultado esperado: uma munição aleatória com atributos aleatórios
        [TestMethod]
        public void TesteGeraMunicao()
        {
            gerador = new Gerador();
            Municao municao = gerador.GeraMunicao();

            Assert.IsNotNull(municao);
        }

        //Testa a geração de uma lista aleatoria de equipamentos
        //Resultado esperado: uma lista de itens equipaveis
        [TestMethod]
        public void TesteGeraListaEquipamentos()
        {
            gerador = new Gerador();
            List<Item> lista = gerador.GeraListaEquipamentos(5, 5);

            Assert.IsTrue(lista.Count > 0);
        }

        //Testa a geração de uma lista de itens aleatórios
        //Resultado esperado: uma lista de itens aleatorios com atributos aleatórios
        [TestMethod]
        public void TesteGeraListaItens()
        {
            gerador = new Gerador();
            List<Item> lista = gerador.GeraListaItens(gerador.GeraInteiro(1, 10));

            Assert.IsTrue(lista.Count > 0);
        }

        //Testa a geração de uma cor aleatória a partir da função GeraCor()
        //Resultado esperado: uma cor aleatória a partir da lista definida dentro da classe Gerador
        [TestMethod]
        public void TesteGeraCor()
        {
            gerador = new Gerador();
            string cor = gerador.GeraCor();

            Assert.IsNotNull(cor);
            Assert.IsTrue(cor != "");
        }

        //Testa a geração de um rei aleatório utilizando a função GeraRei()
        //Resultado esperado: um rei com atributos aleatórios
        [TestMethod]
        public void TesteGeraRei()
        {
            gerador = new Gerador();
            Rei rei = gerador.GeraRei();

            Assert.IsNotNull(rei);
        }

        //Testa a geração de uma lista de reis aleatórios usando a função GeraListaRei()
        //Resultado esperado: uma lista de Reis aleatórios
        [TestMethod]
        public void TesteGeraListaReis()
        {
            gerador = new Gerador();
            List<Rei> lista = gerador.GeraListaReis();

            Assert.IsNotNull(lista);
            Assert.IsTrue(lista.Count > 0);
        }

        //Testa a função GeraInteirosQueSomam que gera numeros aleatorios que no fim somam até um valor
        //Resultado esperado: 5 numeros aleatorios que quando somados dão 100
        [TestMethod]
        public void TesteGeraInteirosQueSomam()
        {
            gerador = new Gerador();
            int[] resultado = gerador.GeraInteirosQueSomam(5, 100);
            int soma = resultado[0] + resultado[1] + resultado[2] + resultado[3] + resultado[4];

            Assert.IsTrue(soma == 100);
        }

        //Testa a função GeraListaEspecies que gera especies aleatorias
        //Resultado esperado: uma lista com quantidade de itens maior que 0
        [TestMethod]
        public void TesteGeraListaEspecies()
        {
            gerador = new Gerador();
            List<Especie> lista = gerador.GeraListaEspecies();

            Assert.IsTrue(lista.Count > 0);

        }

        //Testa a função GeraLong para ver se ela está gerando números aleatórios longos
        //Resultado esperado: um númeroa leatório entre 1000000000 e 10000000000
        [TestMethod]
        public void TesteGeraLong()
        {
            gerador = new Gerador();
            long resultado = gerador.GeraLong(1000000000, 10000000000);

            Assert.IsTrue(resultado >= 1000000000);
            Assert.IsTrue(resultado <= 10000000000);
        }

        //Testa a função GeraValorMag para ver se ela está gerando ValorMag dentro do intervalo
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

        //Testa a geração de uma origem do poder válida
        [TestMethod]
        public void TesteGeraOrigemPoder()
        {
            gerador = new Gerador();

            Assert.IsNotNull(gerador.GeraOrigemPoder());
        }

        //Testa a geração de uma Natureza válida
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

        //Testa a geração de uma Resposta válida
        [TestMethod]
        public void TesteGeraResposta()
        {
            gerador = new Gerador();
            Resposta reacao = gerador.GeraResposta();

            Assert.IsNotNull(reacao);
        }

        //Testa a geração de uma lista de resistências aleatória
        [TestMethod]
        public void TesteGeraResistencias()
        {
            gerador = new Gerador();

            List<Resistencia> lista = gerador.GeraListaResistencias();

            Assert.IsTrue(lista.Count > 0);
        }

    }
}
